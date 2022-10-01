# ========================================== VARS ==========================================  
variable "tfstate_resource_group" {
  type = string
}
variable "tfstate_resource_group_location" {
  type = string
}
variable "tfstate_storage_account_name" {
  type        = string
  description = "Storage Account name in Azure"
}

variable "tfstate_storage_container_name" {
  type        = string
  description = "Storage Container name in Azure"
}
