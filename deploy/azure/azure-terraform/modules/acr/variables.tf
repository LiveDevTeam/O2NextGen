variable "k8s_acr_name" {
  type        = string
  description = "Name for ACR"
}
variable "k8s_cluster_id" {
  type        = string
  description = "Resourse group for AKS cluster"
}
variable "k8s_resource_group" {
  type        = string
  description = "Resourse group for AKS cluster"
}

variable "k8s_location" {
  type        = string
  description = "Resourse group location for AKS cluster"
}
