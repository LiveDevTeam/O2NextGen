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
# resource "azurerm_container_registry" "o2nextgen-aks-acr" {
#   name                = var.k8s_acr_name
#   resource_group_name = var.k8s_resource_group
#   location            = var.k8s_location
#   sku                 = "Standard"
#   admin_enabled       = false
#   depends_on = [
#     azurerm_kubernetes_cluster.o2nextgen-aks
#   ]
# }
# resource "azurerm_role_assignment" "role-acrpull" {
#   scope                = azurerm_container_registry.o2nextgen-aks-acr.id
#   role_definition_name = "AcrPull"
#   principal_id         = azurerm_kubernetes_cluster.o2nextgen-aks.kubelet_identity.0.object_id
#   depends_on = [
#     azurerm_container_registry.o2nextgen-aks-acr,
#     azurerm_kubernetes_cluster.o2nextgen-aks
#   ]
# }

# ============================= AKS PREP - DNS ZONE in AKS ================================  
# =========================================================================================
resource "azurerm_dns_zone" "primary-dns-zone" {
  depends_on = [
    azurerm_kubernetes_cluster.o2nextgen-aks
  ]
  name                = var.k8s_dns_zone
  resource_group_name = var.k8s_resource_group

  tags = {
    "type_product" = "Saas"
    "product"      = "O2NextGen Platform"
  }
}




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


