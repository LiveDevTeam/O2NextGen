provider "helm" {
  kubernetes {
    host                   = var.helm_host
    client_certificate     = var.helm_client_certificate
    client_key             = var.helm_client_key
    cluster_ca_certificate = var.helm_cluster_ca_certificate
  }
}


# current subscription
data "azurerm_subscription" "current" {}

# # current client
data "azuread_client_config" "current" {}