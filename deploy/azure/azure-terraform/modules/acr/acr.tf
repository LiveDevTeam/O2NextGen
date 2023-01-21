# ========================================== ACR ==========================================  
# =========================================================================================
resource "azurerm_role_assignment" "role-acrpull" {
  scope                = azurerm_container_registry.o2nextgen-aks-acr.id
  role_definition_name = "AcrPull"
  principal_id         = var.k8s_cluster_id
  depends_on = [
    azurerm_container_registry.o2nextgen-aks-acr,
  ]
}
resource "azurerm_container_registry" "o2nextgen-aks-acr" {
  name                = var.k8s_acr_name
  resource_group_name = var.k8s_resource_group
  location            = var.k8s_location
  sku                 = "Standard"
  admin_enabled       = false
}
