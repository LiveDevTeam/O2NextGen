
output "current_subscription_display_name" {
  value = data.azurerm_subscription.current.display_name
}

output "object_id" {
  value = data.azuread_client_config.current.object_id
}

# Create an application
resource "azuread_application" "example" {
  display_name = "external-dns"
  owners       = [data.azuread_client_config.current.object_id]
}


# Create Service Principal linked to the Application
resource "azuread_service_principal" "current" {
  application_id               = azuread_application.example.application_id
  app_role_assignment_required = false
  owners                       = [data.azuread_client_config.current.object_id]
}

resource "azuread_application_password" "current" {
  display_name          = "rbac"
  application_object_id = azuread_application.example.object_id
}

# Create role assignment for service principal
# https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/role_assignment
resource "azurerm_role_assignment" "current" {
  scope                = data.azurerm_subscription.current.id
  role_definition_name = "Contributor"

  # When assigning to a SP, use the object_id, not the appId
  # see: https://docs.microsoft.com/en-us/azure/role-based-access-control/role-assignments-cli
  principal_id = azuread_service_principal.current.object_id
}

# Create role assignment for service principal
resource "azurerm_role_assignment" "main" {
  scope                = var.dns_primary_zone_id
  role_definition_name = "DNS Zone Contributor"
  principal_id         = azuread_service_principal.current.object_id
}
# # Create role assignment for service principal
# resource "azurerm_role_assignment" "main-second" {
#   scope                = azurerm_dns_zone.second-dns-zone.id
#   role_definition_name = "DNS Zone Contributor"
#   principal_id         = azuread_service_principal.current.object_id
# }
# resource "azurerm_role_assignment" "main-third" {
#   scope                = azurerm_dns_zone.third-dns-zone.id
#   role_definition_name = "DNS Zone Contributor"
#   principal_id         = azuread_service_principal.current.object_id
# }

# Create role assignment for service principal
resource "azurerm_role_assignment" "reader" {
  scope                = var.k8s_resource_group_id
  role_definition_name = "Reader"
  principal_id         = azuread_service_principal.current.object_id
}

output "display_name" {
  value = azuread_service_principal.current.display_name
}

output "client_id" {
  value = azuread_application.example.application_id
}

output "client_secret" {
  value     = azuread_application_password.current.value
  sensitive = true
}


# ==================================== SSL in AKS =========================================  
# =========================================================================================
resource "helm_release" "cert-manager" {
  name             = "cert-manager"
  namespace        = "cert-manager"
  repository       = "https://charts.jetstack.io"
  chart            = "cert-manager"
  version          = "1.6.1"
  create_namespace = true
  set {
    name  = "installCRDs"
    value = "true"
  }
}

# ============================= External DNS ==========================================  
# =========================================================================================
resource "helm_release" "external-dns" {
  dependency_update = "true"
  name              = "external-dns"
  repository        = "https://charts.bitnami.com/bitnami"
  chart             = "external-dns"
  namespace         = "external-dns"
  create_namespace  = true

  set {
    name  = "azure.cloud"
    value = "AzurePublicCloud"
  }
  set {
    name  = "txtOwnerId"
    value = var.k8s_cluster_name
  }
  set {
    name  = "provider"
    value = "azure"
  }
  set {
    name  = "logLevel"
    value = "debug"
  }
  set {
    name  = "policy"
    value = "sync"
  }
  set {
    name  = "domainFilters"
    value = "{${var.dns_primary_zone}}"
  }
  set {
    name  = "azure.resourceGroup"
    value = var.k8s_resource_group //var.k8s_resource_group //"AzureDNS" //var.k8s_resource_group //"AzureDNS" //
  }
  set {
    name  = "azure.tenantId"
    value = data.azuread_client_config.current.tenant_id
  }
  set {
    name  = "azure.subscriptionId"
    value = data.azurerm_subscription.current.subscription_id
  }
  set {
    name  = "azure.aadClientId"
    value = azuread_application.example.application_id
  }
  set {
    name  = "azure.aadClientSecret"
    value = azuread_application_password.current.value
  }
}