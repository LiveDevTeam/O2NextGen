resource "helm_release" "testapp" {
  name       = "test-app"
  repository = "./charts"
  namespace  = "dev"
  chart      = "test-app"
}

# resource "helm_release" "example" {
#   name  = "redis"
#   chart = "bitnami/redis"
# }
