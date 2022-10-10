# ========================================== RESOURCE ==========================================
resource "azurerm_resource_group" "aks-resource-group" {
  name     = var.k8s_resource_group
  location = var.k8s_location
}

# ========================================== K8S ==========================================  
# resource "azurerm_kubernetes_cluster" "o2nextgen-aks" {
#   name                = var.k8s_cluster_name
#   resource_group_name = var.k8s_resource_group
#   location            = var.k8s_location
#   dns_prefix          = var.k8s_dns_prefix

#   default_node_pool {
#     name                = "system"
#     node_count          = var.k8s_node_count
#     vm_size             = var.k8s_vm_size
#     type                = "VirtualMachineScaleSets"
#     enable_auto_scaling = false
#   }
#   identity {
#     type = "SystemAssigned"
#   }
#   azure_policy_enabled = true
#   # # network_profile {
#   #   load_balancer_sku = "Standard"
#   #   network_plugin    = "kubenet" # azure (CNI)
#   # }

#   tags = {
#     Environment = "Production"
#     Product     = "O2NextGen Platform"
#   }

#   depends_on = [
#     azurerm_resource_group.aks-resource-group
#   ]
# }


