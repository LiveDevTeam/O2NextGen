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

# ========================================== RESOURCE ==========================================  
resource "azurerm_resource_group" "aks-resource-group" {
  name     = var.k8s_resource_group
  location = var.k8s_location
}
