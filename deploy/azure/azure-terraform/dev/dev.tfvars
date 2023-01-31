k8s_resource_group = "development"
k8s_location       = "centralus"


# DNS
dns_primary_zone_name    = "o2bus.com"
dns_second_dns_zone_name = "o2bionics.com"
dns_third_dns_zone_name  = "pfr-centr.com"
dns_resource_group       = "development"
dns_location             = "centralus"

k8s_env = "prod"
# CLUSTER K8S
k8s_cluster_name = "o2nextgen-dev"
k8s_version      = "1.23.12"
k8s_dns_prefix   = "aks"
k8s_vm_size      = "Standard_D2s_v3"
k8s_node_count   = 1 

#ACR
k8s_acr_name = "o2bus"

# Monitoring
grafana_admin_user     = "grafana"
grafana_admin_password = "grafana-pass"
harbor_admin_password  = "#89_DangerSnake?"

# Storage
storage_account_name   = "storageacc017"
storage_container_name = "my-files"
