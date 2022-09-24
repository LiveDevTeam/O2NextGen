resource "azurerm_role_assignment" "role_acrpull" {
  scope                = azurerm_container_registry.acr.id
  role_definition_name = "AcrPull"
  principal_id         = azurerm_kubernetes_cluster.k8s.kubelet_identity.0.object_id
}
resource "azurerm_container_registry" "acr" {
  name                = "o2nextgen"
  resource_group_name = var.aks_group_name
  location            = var.aks_group_location
  sku                 = "Standard"
  admin_enabled       = false
}
