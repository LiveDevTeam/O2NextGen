variable "aks_group_name" {
  type        = string
  description = "Resourse group for AKS cluster"
}

variable "aks_group_location" {
  type        = string
  description = "Resourse group location for AKS cluster"
}

variable "aks_dns_prefix" {
  type        = string
  description = "DNS prefix for AKS Cluster"
}

variable "aks_vm_size" {
  type        = string
  description = "Name VM for AKS Cluster"
}

variable "aks_node_count" {
  type        = number
  description = "Node count for AKS Cluster"
}
variable "aks_cluster_name" {
  type        = string
  description = "AKS Cluster Name"
}
