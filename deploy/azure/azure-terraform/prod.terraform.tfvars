k8s_resource_group = "production"
k8s_location       = "westus3"

# CLUSTER K8S
k8s_cluster_name   = "o2nextgen-prod"
k8s_dns_prefix     = "aks"
k8s_vm_size        = "Standard_D2s_v3"
k8s_node_count     = 1

#ACR
k8s_acr_name = "o2nextgen"

#DNS zones
k8s_primary_dns_zone_name="o2nextgen.com"
k8s_external_dns_name="external-dns-prod"

# Monitoring
grafana_admin_user     = "grafana"
grafana_admin_password = "grafana-pass"