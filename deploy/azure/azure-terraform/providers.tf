provider "azuread" {
}

# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
}
provider "tls" {}
# We strongly recommend using the required_providers block to set the
# Azure Provider source and version being used
terraform {
  backend "azure" {
  }
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = ">= 3.0.0"
    }
    kubernetes = {
      source  = "kubernetes"
      version = "=2.8.0"
    }
    helm = {
      source  = "hashicorp/helm"
      version = ">= 2.5.1"
    }
    azuread = {
      source  = "hashicorp/azuread"
      version = "~> 2.15.0"
    }
    random = {
      source = "hashicorp/random"
    }
    time = {
      source = "hashicorp/time"
    }
  }
}