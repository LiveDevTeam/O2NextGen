
variable "helm_host" {
  type        = string
}

variable "helm_client_certificate" {
  type        = string
}

variable "helm_client_key" {
  type        = string
}

variable "helm_cluster_ca_certificate" {
  type        = string
}

variable "dns_primary_zone" {
  type        = string
  description = "Main DNS zone"
}

variable "dns_primary_zone_id" {
   type        = string
}

variable "k8s_resource_group" {
  type        = string
  description = "Resourse group for AKS cluster"
}

variable "k8s_location" {
  type        = string
  description = "Resourse group location for AKS cluster"
}

variable "k8s_resource_group_id" {
  type        = string
  description = "Resourse group location for AKS cluster"
}
variable "k8s_cluster_name" {
  type        = string
  description = "Resourse group location for AKS cluster"
}
