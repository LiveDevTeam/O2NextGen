variable "k8s_resource_group" {
  type        = string
  description = "Resourse group for AKS cluster"
}

variable "k8s_location" {
  type        = string
  description = "Resourse group location for AKS cluster"
}
variable "k8s_env" {
  type        = string
  description = "env"
}

variable "k8s_version" {
  type        = string
  description = "Kubernetes version"
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

variable "dns_primary_zone_name" {
  type        = string
  description = "main DNS zone"
}

variable "dns_second_dns_zone_name" {
  type        = string
  description = "main DNS zone"
}

variable "dns_third_dns_zone_name" {
  type        = string
  description = "main DNS zone"
}

variable "dns_resource_group" {
  type        = string
  description = "DNS resource group"
}

variable "dns_location" {
  type        = string
  description = "DNS location"
}

variable "k8s_acr_name" {
  type        = string
  description = "Name for ACR"
}

variable "grafana_admin_user" {
  type        = string
  description = "Admin user to access Grafana dashboard"
}

variable "grafana_admin_password" {
  type        = string
  description = "Admin password to access Grafana dashboard"
}

variable "harbor_admin_password" {
  type        = string
  description = "Admin password to access Harbor dashboard"
}


variable "storage_account_name" {
  type        = string
  description = "Storage Account name in Azure"
}

variable "storage_container_name" {
  type        = string
  description = "Storage Container name in Azure"
}