output "host" {
  value = azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.host
}
output "client_certificate" {
  value = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.client_certificate)
}
output "client_key" {
  value = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.client_key)
}
output "cluster_ca_certificate" {
  value = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.cluster_ca_certificate)
}
# host                   = azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.host
#     client_certificate     = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.client_certificate)
#     client_key             = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.client_key)
#     cluster_ca_certificate = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.cluster_ca_certificate)
