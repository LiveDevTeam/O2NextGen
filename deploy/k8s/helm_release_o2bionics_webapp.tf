resource "helm_release" "o2bionicswebappdev" {
  name       = "o2bionics-webapp"
  repository = "./charts"
  namespace  = "dev"
  chart      = "o2bionics-webapp"
}
resource "helm_release" "o2bionicswebappprod" {
  name       = "o2bionics-webapp"
  repository = "./charts"
  namespace  = "prod"
  chart      = "o2bionics-webapp"
}
