LETS_ENCRYPT_EMAIL=live-dev@hotmail.com
cat <<-EOF | kubectl apply --namespace default -f -
apiVersion: cert-manager.io/v1

kind: ClusterIssuer
metadata:
  name: letsencrypt
spec:
  acme:
    server: https://acme-v02.api.letsencrypt.org/directory
    email: $LETS_ENCRYPT_EMAIL
    privateKeySecretRef:
      name: letsencrypt
    solvers:
    - http01:
        ingress:
          class: nginx
EOF


# cat <<-EOF | kubectl apply --namespace apps-prod -f -
# apiVersion: cert-manager.io/v1

# kind: ClusterIssuer
# metadata:
#   name: letsencrypt-prod
# spec:
#   acme:
#     server: https://acme-v02.api.letsencrypt.org/directory
#     email: $LETS_ENCRYPT_EMAIL
#     privateKeySecretRef:
#       name: letsencrypt-prod
#     solvers:
#     - http01:
#         ingress:
#           class: nginx
# EOF

# cat <<-EOF | kubectl apply --namespace apps-staging -f -
# apiVersion: cert-manager.io/v1

# kind: ClusterIssuer
# metadata:
#   name: letsencrypt-staging
# spec:
#   acme:
#     server: https://acme-v02.api.letsencrypt.org/directory
#     email: $LETS_ENCRYPT_EMAIL
#     privateKeySecretRef:
#       name: letsencrypt-staging
#     solvers:
#     - http01:
#         ingress:
#           class: nginx
# EOF

# cat <<-EOF | kubectl apply --namespace apps-dev -f -
# apiVersion: cert-manager.io/v1

# kind: ClusterIssuer
# metadata:
#   name: letsencrypt-dev
# spec:
#   acme:
#     server: https://acme-v02.api.letsencrypt.org/directory
#     email: $LETS_ENCRYPT_EMAIL
#     privateKeySecretRef:
#       name: letsencrypt-dev
#     solvers:
#     - http01:
#         ingress:
#           class: nginx
# EOF


# cat <<-EOF | kubectl apply --namespace apps-devops -f -
# apiVersion: cert-manager.io/v1

# kind: ClusterIssuer
# metadata:
#   name: letsencrypt-devops
# spec:
#   acme:
#     server: https://acme-v02.api.letsencrypt.org/directory
#     email: $LETS_ENCRYPT_EMAIL
#     privateKeySecretRef:
#       name: letsencrypt-devops
#     solvers:
#     - http01:
#         ingress:
#           class: nginx
# EOF