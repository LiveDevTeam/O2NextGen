variable "k8s_resource_group" {
  type        = string
  description = "Resourse group for AKS cluster"
}

variable "k8s_location" {
  type        = string
  description = "Resourse group location for AKS cluster"
}
variable "k8s_cluster_name" {
  type        = string
  description = "AKS cluster name"
}

variable "k8s_dns_prefix" {
  type        = string
  description = "DNS prefix for AKS Cluster"
}

variable "k8s_vm_size" {
  type        = string
  description = "Name VM for AKS Cluster"
}

variable "k8s_node_count" {
  type        = number
  description = "Node count for AKS Cluster"
}

variable "grafana_admin_user" {
  type        = string
  description = "Admin user to access Grafana dashboard"
}

variable "grafana_admin_password" {
  type        = string
  description = "Admin password to access Grafana dashboard"
}

# variable "keyvault_name" {
#   type        = string
#   description = "Keyvault name"
# }

variable "k8s_primary_dns_zone_name" {
  type        = string
  description = "Name PRIMARY DNS ZONE for AKS Cluster"
}
variable "k8s_second_dns_zone_name" {
  type        = string
  description = "Name PRIMARY DNS ZONE for AKS Cluster"
}
variable "k8s_third_dns_zone_name" {
  type        = string
  description = "Name PRIMARY DNS ZONE for AKS Cluster"
}
variable "k8s_acr_name" {
  type        = string
  description = "Name for ACR"
}
