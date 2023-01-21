
# ========================================== RESOURCE ==========================================  
resource "azurerm_resource_group" "aks-resource-group" {
  name     = var.k8s_resource_group
  location = var.k8s_location
}

# ========================================== K8S ========================================== 
resource "azurerm_kubernetes_cluster" "o2nextgen-aks" {
  name                = var.k8s_cluster_name
  resource_group_name = var.k8s_resource_group
  location            = var.k8s_location
  dns_prefix          = var.k8s_dns_prefix
  kubernetes_version  = var.k8s_version

  default_node_pool {
    name                = "system"
    node_count          = var.k8s_node_count
    vm_size             = var.k8s_vm_size
    type                = "VirtualMachineScaleSets"
    enable_auto_scaling = false
  }
  identity {
    type = "SystemAssigned"
  }

  azure_policy_enabled = true

  tags = {
    Environment = var.k8s_env
    Product     = "O2NextGen Platform"
  }

  depends_on = [
    azurerm_resource_group.aks-resource-group
  ]
}

# ============================= AKS PREP - Namespaces in AKS ==============================  
# =========================================================================================
resource "kubernetes_namespace" "prod" {
  metadata {
    annotations = {
      name = "apps-prod"
    }

    labels = {
      Environment = "Production"
    }
    name = "apps-prod"
  }
}

resource "kubernetes_namespace" "dev" {
  metadata {
    annotations = {
      name = "apps-dev"
    }

    labels = {
      Environment = "Development"
    }
    name = "apps-dev"
  }
}

resource "kubernetes_namespace" "tst" {
  metadata {
    annotations = {
      name = "apps-tst"
    }

    labels = {
      Environment = "Test"
    }
    name = "apps-tst"
  }
}

resource "kubernetes_namespace" "staging" {
  metadata {
    annotations = {
      name = "apps-staging"
    }

    labels = {
      Environment = "Staging"
    }
    name = "apps-staging"
  }
}