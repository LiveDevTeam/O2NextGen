# # ========================================== RESOURCE ==========================================  
# resource "azurerm_resource_group" "aks-resource-group" {
#   name     = var.dns_resource_group
#   location = var.dns_location
# }

resource "azurerm_dns_zone" "primary-dns-zone" {
  # depends_on = [
  #   azurerm_resource_group.aks-resource-group
  # ]
  name                = var.dns_primary_zone
  resource_group_name = var.dns_resource_group

  tags = {
    "type_product" = "Saas"
    "product"      = "O2NextGen Platform"
  }
}
