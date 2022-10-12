# ========================================== RESOURCE ==========================================  
resource "azurerm_resource_group" "aks-resource-group" {
  name     = var.k8s_resource_group
  location = var.k8s_location
}
