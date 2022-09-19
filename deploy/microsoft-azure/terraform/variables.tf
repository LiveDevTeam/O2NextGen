variable "resource_group_name" {
  type        = string
  description = "Resource Group in Azure"
}

variable "resource_location_name" {
  type        = string
  description = "Resource Group location in Azure"
}
variable "aks_cluster_name" {
  type        = string
  description = "Name of AKS in Azure"
}
variable "aks_cluster_dns_prefix" {
  type        = string
  description = "dns prefix for cluster aks"
}
variable "azure_acr_name" {
  type = string
  description = "name for ACR"
}
