
resource "kubernetes_namespace" "prod" {
  metadata {
    annotations = {
      name = "prod"
    }

    labels = {
      Environment = "Production"
    }
    name = "prod"
  }
}

resource "kubernetes_namespace" "dev" {
  metadata {
    annotations = {
      name = "dev"
    }

    labels = {
      Environment = "Development"
    }
    name = "dev"
  }
}

resource "kubernetes_namespace" "tst" {
  metadata {
    annotations = {
      name = "tst"
    }

    labels = {
      Environment = "Test"
    }
    name = "tst"
  }
}

resource "kubernetes_namespace" "devops" {
  metadata {
    annotations = {
      name = "devops"
    }

    labels = {
      Environment = "Devops"
    }
    name = "devops"
  }
}