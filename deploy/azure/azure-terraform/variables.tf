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
