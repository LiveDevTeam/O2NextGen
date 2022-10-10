# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
}

provider "helm" {
  kubernetes {
    host                   = azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.host
    client_certificate     = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.client_certificate)
    client_key             = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.client_key)
    cluster_ca_certificate = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.cluster_ca_certificate)
  }
}

provider "kubernetes" {
  host                   = azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.host
  client_certificate     = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.client_certificate)
  client_key             = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.client_key)
  cluster_ca_certificate = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.cluster_ca_certificate)
}

# # Configure the Azure Active Directory Provider
# provider "azuread" {
#   tenant_id = "f3a52f65-e3a4-4386-8bc9-a42f32fc1cd6"
# }
# provider "azuread" {
#   # NOTE: Environment Variables can also be used for Service Principal authentication
#   # Terraform also supports authenticating via the Azure CLI too.
#   # see here for more info: http://terraform.io/docs/providers/azuread/index.html

#   # subscription_id = "..."
#   # client_id       = "..."
#   # client_secret   = "..."
#   # tenant_id       = "..."
# }
# Configure the Azure Active Directory Provider
provider "azuread" {
  # subscription_id="f1404c6e-2728-40ae-9cd2-fee75bde4c04"
  tenant_id = "f3a52f65-e3a4-4386-8bc9-a42f32fc1cd6"
}

provider "tls" {}
# We strongly recommend using the required_providers block to set the
# Azure Provider source and version being used
terraform {
#     backend "azurerm" {
#   }
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


# Retrieve domain information
data "azuread_domains" "example" {
  only_initial = true
}


# ========================================== RESOURCE ==========================================  
resource "azurerm_resource_group" "tfstate-resource-group" {
  name     = var.tfstate_resource_group
  location = var.tfstate_resource_group_location
}

resource "azurerm_storage_account" "storage" {
  name                     = var.tfstate_storage_account_name
  resource_group_name      = azurerm_resource_group.tfstate-resource-group.name
  location                 = var.tfstate_resource_group_location
  account_tier             = "Standard"
  account_replication_type = "LRS"
  allow_nested_items_to_be_public = true
}

resource "azurerm_storage_container" "container" {
  name                  = var.tfstate_storage_container_name
  storage_account_name  = azurerm_storage_account.storage.name
  container_access_type = "container" # "blob" "private"
}