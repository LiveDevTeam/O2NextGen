# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
}

terraform {
  backend "azurerm" {
  }
  backend "kubernetes" {
  }
  required_providers {

  }
}
