resource "azurerm_kubernetes_cluster" "k8s" {
  resource_group_name = var.aks_group_name
  location            = var.aks_group_location
}
