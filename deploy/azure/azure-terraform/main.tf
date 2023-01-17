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

module "dns" {
  source             = "./modules/dns"
  dns_primary_zone   = var.dns_primary_zone_name
  dns_resource_group = var.dns_resource_group
  dns_location       = var.dns_location
}
