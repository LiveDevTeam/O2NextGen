# Configure the Azure Active Directory Provider
provider "azuread" {
  # subscription_id="f1404c6e-2728-40ae-9cd2-fee75bde4c04"
  # tenant_id = "f3a52f65-e3a4-4386-8bc9-a42f32fc1cd6"
}

# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
}

# We strongly recommend using the required_providers block to set the
# Azure Provider source and version being used
terraform {
   backend "azure" {
    # resource_group_name  = "devops-tfstate"
    # storage_account_name = "terraformstate999"
    # container_name       = "tfstate"
    # key                  = "terraform.tfstate"
  }
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=3.0.0"
    }
    azuread = {
      source  = "hashicorp/azuread"
      version = "~> 2.15.0"
    }
  }
}


