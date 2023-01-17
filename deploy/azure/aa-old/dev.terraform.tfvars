k8s_cluster_name   = "o2nextgen-aks"
k8s_resource_group = "develop"
k8s_location       = "centralus"
k8s_dns_prefix     = "aks"
k8s_vm_size        = "Standard_B2ms"
k8s_node_count     = 1
k8s_vm_pool2_size        = "Standard_B2ms"
k8s_node_pool2_count     = 1
o2nextgen-aks
grafana_admin_user     = "grafana"
grafana_admin_password = "grafana-pass"
k8s_acr_name = "o2nextgen"
keyvault_name = "o2nextgen-keyvault-dev"
# harbor_admin_password  = "Harbor12345" # "harbor-pass"
