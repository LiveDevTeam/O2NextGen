# Configure the Azure Active Directory Provider
provider "azuread" {
}

# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
}

terraform {
  # backend "azure" {
  # }
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = ">= 3.0.0"
    }
    azuread = {
      source  = "hashicorp/azuread"
      version = "~> 2.15.0"
    }
  }
}
