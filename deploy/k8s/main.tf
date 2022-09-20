resource "azurerm_resource_group" "rg" {
  name     = var.aks_group_name
  location = var.aks_group_location
}
