k8s_cluster_name   = "o2nextgen-aks"
k8s_resource_group = "products"
k8s_location       = "westus3"
k8s_dns_prefix     = "aks"
k8s_vm_size        = "Standard_D2s_v3"
k8s_node_count     = 3
k8s_vm_pool2_size        = "Standard_B2ms"
k8s_node_pool2_count     = 1

grafana_admin_user     = "grafana"
grafana_admin_password = "grafana-pass"

keyvault_name = "o2nextgen-keyvault"
# harbor_admin_password  = "Harbor12345" # "harbor-pass"
