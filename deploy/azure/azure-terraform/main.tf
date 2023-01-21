module "dns" {
  source             = "./modules/dns"
  dns_primary_zone   = var.dns_primary_zone_name
  dns_resource_group = var.dns_resource_group
  dns_location       = var.dns_location
}

# module "dns2" {
#   source             = "./modules/dns"
#   dns_primary_zone   = var.dns_second_dns_zone_name
#   dns_resource_group = var.dns_resource_group
#   dns_location       = var.dns_location
# }

# module "dns3" {
#   source             = "./modules/dns"
#   dns_primary_zone   = var.dns_third_dns_zone_name
#   dns_resource_group = var.dns_resource_group
#   dns_location       = var.dns_location
# }

module "aks" {
  source             = "./modules/aks"
  k8s_resource_group = var.k8s_resource_group
  k8s_cluster_name   = var.k8s_cluster_name
  k8s_dns_prefix     = var.k8s_dns_prefix
  k8s_env            = var.k8s_env
  k8s_location       = var.k8s_location
  k8s_node_count     = var.k8s_node_count
  k8s_version        = var.k8s_version
  k8s_vm_size        = var.k8s_vm_size
}

module "monitoring" {
  source                      = "./modules/monitoring"
  grafana_admin_user          = var.grafana_admin_user
  grafana_admin_password      = var.grafana_admin_password
  helm_host                   = module.aks.host
  helm_client_certificate     = module.aks.client_certificate
  helm_client_key             = module.aks.client_key
  helm_cluster_ca_certificate = module.aks.cluster_ca_certificate
  # harbor_admin_password       = var.harbor_admin_password
}

module "tls" {
  source                      = "./modules/tls"
  dns_primary_zone            = var.dns_primary_zone_name
  dns_primary_zone_id         = module.dns.dns_primary_zone_id
  helm_host                   = module.aks.host
  helm_client_certificate     = module.aks.client_certificate
  helm_client_key             = module.aks.client_key
  helm_cluster_ca_certificate = module.aks.cluster_ca_certificate

  k8s_resource_group    = var.k8s_resource_group
  k8s_resource_group_id = module.aks.k8s_resource_group_id
  k8s_location          = var.k8s_location
  k8s_cluster_name      = var.k8s_cluster_name
}

module "acr" {
  depends_on = [
    module.aks
  ]
  source             = "./modules/acr"
  k8s_acr_name       = var.k8s_acr_name
  k8s_cluster_id     = module.aks.k8s_cluster_id
  k8s_resource_group = var.k8s_resource_group
  k8s_location       = var.k8s_location
}
