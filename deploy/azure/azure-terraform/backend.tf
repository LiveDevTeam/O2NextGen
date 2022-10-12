terraform {
  backend "azurerm" {
    resource_group_name  = "devops-tfstate"
    storage_account_name = "terraformstate999"
    container_name       = "tfstate"
    key                  = "terraform.tfstate"
  }
}
