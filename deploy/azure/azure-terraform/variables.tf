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

variable "k8s_acr_name"{
  type        = string
  description = "ACR Name for AKS Cluster"
}
variable "k8s_dns_zone" {
  type        = string
  description = "Primary DNS Zone for AKS Cluster"
}