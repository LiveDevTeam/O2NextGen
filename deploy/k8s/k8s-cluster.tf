resource "azurerm_kubernetes_cluster" "k8s" {
  name                = var.aks_cluster_name
  resource_group_name = var.aks_group_name
  location            = var.aks_group_location
  dns_prefix          = var.aks_dns_prefix

  default_node_pool {
    name                = "system"
    node_count          = var.aks_node_count
    vm_size             = var.aks_vm_size
    enable_auto_scaling = false
  }
  identity {
    type = "SystemAssigned"
  }

  tags = {
    Environment = "Production"
    Product     = "O2NextGen Platform"
  }
}
