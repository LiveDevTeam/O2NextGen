# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
}
provider "kubernetes" {
  host                   = azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.host
  client_certificate     = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.client_certificate)
  client_key             = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.client_key)
  cluster_ca_certificate = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.cluster_ca_certificate)
}
provider "helm" {
  kubernetes {
    host                   = azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.host
    client_certificate     = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.client_certificate)
    client_key             = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.client_key)
    cluster_ca_certificate = base64decode(azurerm_kubernetes_cluster.o2nextgen-aks.kube_config.0.cluster_ca_certificate)
  }
}
# Retrieve domain information
data "azuread_domains" "example" {
  only_initial = true
}

# Configure the Azure Active Directory Provider
provider "azuread" {
  # subscription_id="f1404c6e-2728-40ae-9cd2-fee75bde4c04"
  tenant_id = "f3a52f65-e3a4-4386-8bc9-a42f32fc1cd6"
}

provider "tls" {}

terraform {
  required_version = ">=0.14.0"
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
