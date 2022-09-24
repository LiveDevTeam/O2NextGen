# ##########
# # data sources
# ##########################
# data "azurerm_client_config" "current" {}


# resource "helm_release" "extdns" {
#   name             = "external-dns"
#   repository       = "https://charts.bitnami.com/bitnami"
#   chart            = "external-dns"
#   namespace        = "external-dns"
#   create_namespace = true
# }
