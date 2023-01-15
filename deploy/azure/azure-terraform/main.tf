# ========================================== RESOURCE ==========================================  
resource "azurerm_resource_group" "aks-resource-group" {
  name     = var.k8s_resource_group
  location = var.k8s_location
}

# ========================================== K8S ========================================== 
resource "azurerm_kubernetes_cluster" "o2nextgen-aks" {
  name                = var.k8s_cluster_name
  resource_group_name = var.k8s_resource_group
  location            = var.k8s_location
  dns_prefix          = var.k8s_dns_prefix

  default_node_pool {
    name                = "system"
    node_count          = var.k8s_node_count
    vm_size             = var.k8s_vm_size
    type                = "VirtualMachineScaleSets"
    enable_auto_scaling = false
  }
  identity {
    type = "SystemAssigned"
  }
  azure_policy_enabled = true
  # # network_profile {
  #   load_balancer_sku = "Standard"
  #   network_plugin    = "kubenet" # azure (CNI)
  # }

  tags = {
    Environment = "Production"
    Product     = "O2NextGen Platform"
  }

  depends_on = [
    azurerm_resource_group.aks-resource-group
  ]
}

# ========================================== ACR ==========================================  
# =========================================================================================
resource "azurerm_role_assignment" "role-acrpull" {
  scope                = azurerm_container_registry.o2nextgen-aks-acr.id
  role_definition_name = "AcrPull"
  principal_id         = azurerm_kubernetes_cluster.o2nextgen-aks.kubelet_identity.0.object_id
  depends_on = [
    azurerm_container_registry.o2nextgen-aks-acr,
    azurerm_kubernetes_cluster.o2nextgen-aks
  ]
}
resource "azurerm_container_registry" "o2nextgen-aks-acr" {
  name                = var.k8s_acr_name
  resource_group_name = var.k8s_resource_group
  location            = var.k8s_location
  sku                 = "Standard"
  admin_enabled       = false
  depends_on = [
    azurerm_kubernetes_cluster.o2nextgen-aks
  ]
}

# ============================= AKS PREP - DNS ZONE in AKS ================================  
# =========================================================================================
resource "azurerm_dns_zone" "primary-dns-zone" {
  depends_on = [
    azurerm_kubernetes_cluster.o2nextgen-aks
  ]
  name                = var.k8s_primary_dns_zone_name
  resource_group_name = var.k8s_resource_group

  tags = {
    "type_product" = "Saas"
    "product"      = "O2NextGen Platform"
  }
}

# =========================================== DNS ========================================= 
# =========================================================================================
# current subscription
data "azurerm_subscription" "current" {}

# # current client
data "azuread_client_config" "current" {}

output "current_subscription_display_name" {
  value = data.azurerm_subscription.current.display_name
}

output "object_id" {
  value = data.azuread_client_config.current.object_id
}

# Create an application
resource "azuread_application" "example" {
  depends_on = [
    azurerm_dns_zone.primary-dns-zone
  ]
  display_name = var.k8s_external_dns_name
  owners       = [data.azuread_client_config.current.object_id]
}

# Create Service Principal linked to the Application
resource "azuread_service_principal" "current" {
  application_id               = azuread_application.example.application_id
  app_role_assignment_required = false
  owners                       = [data.azuread_client_config.current.object_id]
}

resource "azuread_application_password" "current" {
  display_name          = "rbac"
  application_object_id = azuread_application.example.object_id
}

# Create role assignment for service principal
# https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/role_assignment
resource "azurerm_role_assignment" "current" {
  scope                = data.azurerm_subscription.current.id
  role_definition_name = "Contributor"

  # When assigning to a SP, use the object_id, not the appId
  # see: https://docs.microsoft.com/en-us/azure/role-based-access-control/role-assignments-cli
  principal_id = azuread_service_principal.current.object_id
}

# Create role assignment for service principal
resource "azurerm_role_assignment" "main" {
  scope                = azurerm_dns_zone.primary-dns-zone.id
  role_definition_name = "DNS Zone Contributor"
  principal_id         = azuread_service_principal.current.object_id
}

# Create role assignment for service principal ???
resource "azurerm_role_assignment" "reader" {
  scope                = azurerm_resource_group.aks-resource-group.id
  role_definition_name = "Reader"
  principal_id         = azuread_service_principal.current.object_id
}

output "display_name" {
  value = azuread_service_principal.current.display_name
}

output "client_id" {
  value = azuread_application.example.application_id
}

output "client_secret" {
  value     = azuread_application_password.current.value
  sensitive = true
}

# ============================= MONITORING TOOLS ==========================================  
# =========================================================================================
resource "helm_release" "aad-pod-identity" {
  depends_on = [
    azurerm_resource_group.aks-resource-group,
    azurerm_kubernetes_cluster.o2nextgen-aks,
    azurerm_container_registry.o2nextgen-aks-acr
  ]
  name       = "aad-pod-identity"
  repository = "https://raw.githubusercontent.com/Azure/aad-pod-identity/master/charts"
  chart      = "aad-pod-identity"
  namespace  = "kube-system"
}

# https://github.com/kubernetes/ingress-nginx/tree/main/charts/ingress-nginx
resource "helm_release" "nginx-ingress-controller" {
  name             = "nginx-ingress-controller"
  repository       = "https://kubernetes.github.io/ingress-nginx"
  chart            = "ingress-nginx"
  version          = "4.1.3"
  namespace        = "ingress"
  create_namespace = "true"

  set {
    name  = "controller.service.type"
    value = "LoadBalancer"
  }
  set {
    name  = "controller.autoscaling.enabled"
    value = "true"
  }
  set {
    name  = "controller.autoscaling.minReplicas"
    value = "1"
  }
  set {
    name  = "controller.autoscaling.maxReplicas"
    value = "1"
  }
}

# https://github.com/prometheus-community/helm-charts/tree/main/charts/kube-prometheus-stack
resource "helm_release" "prometheus-stack" {
  depends_on = [
    helm_release.nginx-ingress-controller
  ]
  name             = "prometheus-stack"
  repository       = "https://prometheus-community.github.io/helm-charts"
  chart            = "kube-prometheus-stack"
  namespace        = "monitoring"
  create_namespace = true

  set {
    name  = "grafana.ingress.enabled"
    value = "true"
  }
  set {
    name  = "grafana.ingress.ingressClassName"
    value = "nginx"
  }
  # set {
  #   name  = "server.ingress.pathType"
  #   value = "Prefix"
  # }
  set {
    name  = "grafana.ingress.path"
    value = "/(.*)" # "/grafana2/?(.*)"
  }
  # annotations:
  #   nginx.ingress.kubernetes.io/ssl-redirect: "false"
  #   nginx.ingress.kubernetes.io/use-regex: "true"
  #   nginx.ingress.kubernetes.io/rewrite-target: /$1
  set {
    name  = "grafana.ingress.annotations.nginx\\.ingress\\.kubernetes\\.io/ssl-redirect"
    value = "false"
    type  = "string"
  }
  set {
    name  = "grafana.ingress.annotations.nginx\\.ingress\\.kubernetes\\.io/use-regex"
    value = "true"
    type  = "string"
  }
  set {
    name  = "grafana.ingress.annotations.nginx\\.ingress\\.kubernetes\\.io/rewrite-target"
    value = "/$1"
  }
  set {
    name  = "grafana.adminUser"
    value = var.grafana_admin_user
  }
  set {
    name  = "grafana.adminPassword"
    value = var.grafana_admin_password
  }
}

# ============================= External DNS ==========================================  
# =========================================================================================
resource "helm_release" "external-dns" {
  depends_on = [
    azurerm_dns_zone.primary-dns-zone
  ]
  dependency_update = "true"
  name              = "external-dns"
  repository        = "https://charts.bitnami.com/bitnami"
  chart             = "external-dns"
  namespace         = "external-dns"
  create_namespace  = true
  # values = [
  #   local.dnsValues
  # ]
  set {
    name  = "azure.cloud"
    value = "AzurePublicCloud"
  }
  set {
    name  = "txtOwnerId"
    value = azurerm_kubernetes_cluster.o2nextgen-aks.name
  }
  set {
    name  = "provider"
    value = "azure"
  }
  set {
    name  = "logLevel"
    value = "debug"
  }
  set {
    name  = "policy"
    value = "sync"
  }
  set {
    name  = "domainFilters"
    value = "{${azurerm_dns_zone.primary-dns-zone.name}}"
  }
  set {
    name  = "azure.resourceGroup"
    value = azurerm_kubernetes_cluster.o2nextgen-aks.resource_group_name //var.k8s_resource_group //"AzureDNS" //var.k8s_resource_group //"AzureDNS" //
  }
  set {
    name  = "azure.tenantId"
    value = data.azuread_client_config.current.tenant_id
  }
  set {
    name  = "azure.subscriptionId"
    value = data.azurerm_subscription.current.subscription_id
  }
  set {
    name  = "azure.aadClientId"
    value = azuread_application.example.application_id
  }
  set {
    name  = "azure.aadClientSecret"
    value = azuread_application_password.current.value
  }
}

# ============================= AKS PREP - Namespaces in AKS ==============================  
# =========================================================================================
resource "kubernetes_namespace" "prod" {
  metadata {
    annotations = {
      name = "apps-prod"
    }

    labels = {
      Environment = "Production"
    }
    name = "apps-prod"
  }
}

# ==================================== SSL in AKS =========================================  
# =========================================================================================
resource "helm_release" "cert-manager" {
  name             = "cert-manager"
  namespace        = "cert-manager"
  repository       = "https://charts.jetstack.io"
  chart            = "cert-manager"
  version          = "1.6.1"
  create_namespace = true
  set {
    name  = "installCRDs"
    value = "true"
  }
  set {
      name  = "domainFilters"
      value = "{${azurerm_dns_zone.primary-dns-zone.name}}"
  }
}