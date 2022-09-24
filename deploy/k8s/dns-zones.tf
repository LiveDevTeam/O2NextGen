# resource "azurerm_dns_zone" "primary" {
#   name                = "o2bus.com"
#   resource_group_name = var.aks_group_name

#   tags = {
#     "type_product" = "Saas"
#     "product"      = "O2NextGen Platform"
#   }
# }

# # resource "azurerm_dns_a_record" "o2bus_com" {
# #   name                = "www"
# #   zone_name           = azurerm_dns_zone.primary.name
# #   resource_group_name = azurerm_dns_zone.primary.resource_group_name
# #   ttl                 = 300
# #   records             = ["10.0.180.17"] #load balancer ip
# # }

# resource "azurerm_dns_zone" "second" {
#   name                = "prf-cent.com"
#   resource_group_name = var.aks_group_name

#   tags = {
#     "type"         = "client"
#     "type_product" = "Saas"
#     "product"      = "O2NextGen Platform"
#   }
# }
