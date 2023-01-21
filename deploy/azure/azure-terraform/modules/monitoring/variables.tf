variable "grafana_admin_user" {
  type        = string
  description = "Admin user to access Grafana dashboard"
}

variable "grafana_admin_password" {
  type        = string
  description = "Admin password to access Grafana dashboard"
}

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