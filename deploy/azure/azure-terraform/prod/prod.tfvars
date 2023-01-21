k8s_resource_group = "o2nextgen-prod"
k8s_location       = "westus3"


# DNS
dns_primary_zone_name = "o2nextgen.com"
dns_resource_group = "o2nextgen-dns"
dns_location = "centralus"

k8s_env = "prod"
# CLUSTER K8S
k8s_cluster_name = "o2nextgen-prod"
k8s_version      = "1.24.6"
k8s_dns_prefix   = "aks"
k8s_vm_size      = "Standard_B2ms"
k8s_node_count   = 1

# Monitoring
grafana_admin_user     = "grafana"
grafana_admin_password = "grafana-pass"