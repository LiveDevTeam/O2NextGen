

provider "helm" {
  kubernetes {
    host                   = azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.host
    client_certificate     = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.client_certificate)
    client_key             = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.client_key)
    cluster_ca_certificate = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.cluster_ca_certificate)
  }
}

provider "kubernetes" {
  host                   = azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.host
  client_certificate     = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.client_certificate)
  client_key             = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.client_key)
  cluster_ca_certificate = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.cluster_ca_certificate)
}

# Configure the Azure Active Directory Provider
provider "azuread" {
  # subscription_id="f1404c6e-2728-40ae-9cd2-fee75bde4c04"
  # tenant_id = "f3a52f65-e3a4-4386-8bc9-a42f32fc1cd6"
}
# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
}
provider "tls" {}
# We strongly recommend using the required_providers block to set the
# Azure Provider source and version being used
terraform {
  backend "azure" {
  }
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = ">= 3.0.0"
    }
    kubernetes = {
      source  = "kubernetes"
      version = "=2.8.0"
    }
    helm = {
      source  = "hashicorp/helm"
      version = ">= 2.5.1"
    }
    azuread = {
      source  = "hashicorp/azuread"
      version = "~> 2.15.0"
    }
    random = {
      source = "hashicorp/random"
    }
    time = {
      source = "hashicorp/time"
    }
  }
}

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
  kubernetes_version  = var.k8s_version
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
  name                = var.dns_primary_zone_name
  resource_group_name = var.k8s_resource_group

  tags = {
    "type_product" = "Saas"
    "product"      = "O2NextGen Platform"
  }
}
resource "azurerm_dns_zone" "second-dns-zone" {
  depends_on = [
    azurerm_kubernetes_cluster.o2nextgen-aks
  ]
  name                = var.dns_second_dns_zone_name
  resource_group_name = var.k8s_resource_group

  tags = {
    "type"         = "client"
    "type_product" = "Saas"
    "product"      = "O2NextGen Platform"
  }
}
resource "azurerm_dns_zone" "third-dns-zone" {
  depends_on = [
    azurerm_kubernetes_cluster.o2nextgen-aks
  ]
  name                = var.dns_third_dns_zone_name
  resource_group_name = var.k8s_resource_group

  tags = {
    "type"         = "offsite"
    "type_product" = "Saas"
    "product"      = "O2NextGen Platform"
  }
}

# resource "azuread_application" "example" {
#   display_name = "sp-external-dns"
#   owners       = [data.azuread_client_config.current.object_id]
# }
# resource "azuread_service_principal" "sp-external-dns" {
#   principal_id = azuread_service_principal.sp-external-dns.template_id
# }

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
  display_name = "external-dns"
  owners       = [data.azuread_client_config.current.object_id]
}

# # Create a service principal
# resource "azuread_service_principal" "example" {
#   application_id = azuread_application.example.application_id
#   owners         = [data.azuread_client_config.current.object_id]
# }

# Create Service Principal linked to the Application
resource "azuread_service_principal" "current" {
  application_id               = azuread_application.example.application_id
  app_role_assignment_required = false
  owners                       = [data.azuread_client_config.current.object_id]
}

# # Create role assignment for Service Principal
# resource "azurerm_role_assignment" "contributor" {
#   scope                = data.azurerm_subscription.current.id
#   role_definition_name = "Contributor"
#   principal_id         = azuread_service_principal.current.id
# }

# # # Generate random string to be used for Service Principal password
# resource "random_string" "password" {
#   length  = 32
#   special = true
# }
resource "azuread_application_password" "current" {
  display_name          = "rbac"
  application_object_id = azuread_application.example.object_id
}

# off azurerm_key_vault
# resource "azurerm_key_vault" "keyvault" {
#   name                        = var.keyvault_name
#   location                    = var.k8s_location
#   resource_group_name         = var.k8s_resource_group
#   enabled_for_disk_encryption = false
#   tenant_id                   = data.azuread_client_config.current.tenant_id
#   soft_delete_retention_days  = 7
#   purge_protection_enabled    = false

#   sku_name = "standard"

#   access_policy {
#     tenant_id = data.azuread_client_config.current.tenant_id
#     object_id = data.azuread_client_config.current.object_id

#     key_permissions = [
#       "Get",
#     ]

#     secret_permissions = [
#       "Get",
#       "List",
#       "Set",
#       "Delete"
#     ]

#     storage_permissions = [
#       "Get",
#     ]
#   }

#   # network_acls {
#   #   default_action = "Deny" # "Allow" 
#   #   bypass         = "AzureServices" # "None"
#   #   ip_rules = ["50.50.50.50/24"]
#   # }
# }
# resource "time_rotating" "example" {
#   rotation_days = 7
# }
# # Create Service Principal password
# resource "azuread_service_principal_password" "main" {
#   service_principal_id = azuread_service_principal.current.object_id
#   rotate_when_changed = {
#     rotation = time_rotating.example.id
#   }
# }

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
# Create role assignment for service principal
resource "azurerm_role_assignment" "main-second" {
  scope                = azurerm_dns_zone.second-dns-zone.id
  role_definition_name = "DNS Zone Contributor"
  principal_id         = azuread_service_principal.current.object_id
}
resource "azurerm_role_assignment" "main-third" {
  scope                = azurerm_dns_zone.third-dns-zone.id
  role_definition_name = "DNS Zone Contributor"
  principal_id         = azuread_service_principal.current.object_id
}

# Create role assignment for service principal
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


# # Generate a private key
# resource "tls_private_key" "example" {
#   algorithm = "RSA"
#   rsa_bits  = 2048
# }

# # Generate a self signed certificate
# resource "tls_self_signed_cert" "example" {
#   private_key_pem = tls_private_key.example.private_key_pem

#   subject {
#     common_name  = azuread_application.example.display_name
#     organization = "O2 Bionics LLC"
#   }

#   allowed_uses          = ["client_auth", "server_auth"]
#   validity_period_hours = 8760
# }

# # Create Application certificate (client certificate)
# resource "azuread_application_certificate" "example" {
#   application_object_id = azuread_application.example.object_id
#   type                  = "AsymmetricX509Cert"
#   end_date_relative     = "4320h" # expire in 6 months
#   value                 = tls_self_signed_cert.example.cert_pem
# }

# # Create Application password (client secret)
# resource "azuread_application_password" "example" {
#   application_object_id = azuread_application.example.object_id
#   end_date_relative     = "4320h" # expire in 6 months
# }
# output "account_id" {
#   value = data.azurerm_client_config.current.service_principal_application_id
# }

# resource "azuread_application" "example" {
#   display_name = "External-DNS-SP"
#   owners       = [data.azurerm_client_config.current.object_id]
# }

# resource "azuread_service_principal" "example" {
#   application_id               = azuread_application.example.application_id
#   app_role_assignment_required = false
#   owners                       = [data.azurerm_client_config.current.object_id]
# }

# data "azuread_application_template" "example" {
#   display_name = "External-DNS-SP"
# }

# resource "azuread_application" "example" {
#   display_name = "sp-external-dns"
#   template_id  = data.azuread_application_template.example.template_id
# }

# resource "azuread_service_principal" "example" {
#   application_id = azuread_application.example.application_id
#   use_existing   = true
# }

# resource "azurerm_role_assignment" "role-secret-officer" {
#   role_definition_name = "Key Vault Secrets Officer"
#   principal_id         = data.azurerm_client_config.current.object_id
#   scope                = azurerm_key_vault.keyvault.id
# }
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
    value = "2"
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

# resource "helm_release" "redis" {
#   name             = "redis"
#   repository       = "https://charts.bitnami.com/bitnami"
#   chart            = "redis"
#   version          = "16.11.2"
#   namespace        = "redis-app"
#   create_namespace = true

#   # values = [
#   #   "${file("values.yaml")}"
#   # ]

#   set {
#     name  = "cluster.enabled"
#     value = "true"
#   }

#   set {
#     name  = "metrics.enabled"
#     value = "true"
#   }

#   set {
#     name  = "service.annotations.prometheus\\.io/port"
#     value = "9127"
#     type  = "string"
#   }
# }

locals {
  dnsValues = <<EOF
  args:
    - --txtOwnerId=${azurerm_kubernetes_cluster.o2nextgen-aks.name}
    - --provider=azure
    - --azure.resourceGroup=${azurerm_kubernetes_cluster.o2nextgen-aks.resource_group_name}
    - --azure.tenantId=${data.azuread_client_config.current.tenant_id}
    - --azure.subscriptionId=${data.azurerm_subscription.current.id}
    - --azure.aadClientId=${azuread_application.example.application_id}
    - --azure.aadClientSecret="${azuread_application_password.current.value}"
    - --azure.cloud=AzurePublicCloud
    - --policy=sync
    - --domain-filter=${azurerm_dns_zone.primary-dns-zone.name}
    - --domain-filter=${azurerm_dns_zone.second-dns-zone.name}
    - --domain-filter=${azurerm_dns_zone.third-dns-zone.name}
EOF
}

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
    value = "{${azurerm_dns_zone.primary-dns-zone.name},${azurerm_dns_zone.second-dns-zone.name},${azurerm_dns_zone.third-dns-zone.name}}"
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
  # # set {
  # #   name  = "azure.useManagedIdentityExtension"
  # #   value = "true"
  # # }
  # # set {
  # #   name  = "azure.userAssignedIdentityID"
  # #   value = azuread_service_principal.current.id
  # # }

  # --set txtOwnerId=$AZ_AKS_NAME \
  #   --set provider=azure \
  #   --set azure.resourceGroup=$AZ_DNS_GROUP \
  #   --set azure.tenantId=$AZ_TENANT_ID \
  #   --set azure.subscriptionId=$AZ_SUBSCRIPTION_ID \
  #   --set azure.aadClientId=$SP_CLIENT_ID \
  #   --set azure.aadClientSecret="$SP_CLIENT_SECRET" \
  #   --set azure.cloud=AzurePublicCloud \
  #   --set policy=sync \
  #   --set domainFilters={$DOMAIN_NAME}

}

resource "helm_release" "cert-manager" {
  name             = "cert-manager"
  namespace        = "cert-manager"
  repository       = "https://charts.jetstack.io"
  chart            = "cert-manager"
  version          = "1.9.1"
  create_namespace = true
  set {
    name  = "installCRDs"
    value = "true"
  }
  # set {
  #   name  = "domainFilters"
  #   value = "o2bus.com"
  # }
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

resource "kubernetes_namespace" "dev" {
  metadata {
    annotations = {
      name = "apps-dev"
    }

    labels = {
      Environment = "Development"
    }
    name = "apps-dev"
  }
}

resource "kubernetes_namespace" "tst" {
  metadata {
    annotations = {
      name = "apps-tst"
    }

    labels = {
      Environment = "Test"
    }
    name = "apps-tst"
  }
}

resource "kubernetes_namespace" "staging" {
  metadata {
    annotations = {
      name = "apps-staging"
    }

    labels = {
      Environment = "Staging"
    }
    name = "apps-staging"
  }
}

resource "kubernetes_namespace" "devops" {
  metadata {
    annotations = {
      name = "apps-devops"
    }

    labels = {
      Environment = "Devops"
    }
    name = "apps-devops"
  }
}

# ======== Storage ========
resource "azurerm_storage_account" "storage" {
  name                     = var.storage_account_name
  resource_group_name      = var.k8s_resource_group
  location                 = var.k8s_location
  account_tier             = "Standard"
  account_replication_type = "LRS"
  allow_blob_public_access = true
}

resource "azurerm_storage_container" "container" {
  name                  = var.storage_container_name
  storage_account_name  = azurerm_storage_account.storage.name
  container_access_type = "container" # "blob" "private"
}

# resource "azurerm_storage_blob" "blob" {
#   name                   = "sample-file.sh"
#   storage_account_name   = azurerm_storage_account.storage.name
#   storage_container_name = azurerm_storage_container.container.name
#   type                   = "Block"
#   source                 = "commands.sh"
# }

# ============================= INSTALL APPLICATION =======================================  
# =========================================================================================
# resource "helm_release" "o2nextgen-auth" {
#   name       = "o2nextgen-auth"
#   namespace  = "apps-prod"
#   repository = "../../../helm_charts"
#   chart      = "o2nextgen-auth"
# }

# resource "helm_release" "o2bus-webapp" {
#   name       = "o2bus-webapp"
#   namespace  = "apps-prod"
#   repository = "../../../helm_charts"
#   chart      = "o2bus-webapp"
# }

# resource "helm_release" "cgen-webapp" {
#   name       = "cgen-webapp"
#   namespace  = "apps-prod"
#   repository = "../../../helm_charts"
#   chart      = "cgen-webapp"
# }
