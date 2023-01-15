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
          serviceType: ClusterIP
          class: nginx
    - dns01:
        azuredns:
          clientID: AZURE_CERT_MANAGER_SP_APP_ID
          clientSecretSecretRef:
          # The following is the secret we created in Kubernetes. Issuer will use this to present challenge to Azure DNS.
            name: azuredns-config
            key: client-secret
          subscriptionID: AZURE_SUBSCRIPTION_ID
          tenantID: AZURE_TENANT_ID
          resourceGroupName: AZURE_DNS_ZONE_RESOURCE_GROUP
          hostedZoneName: AZURE_DNS_ZONE
          # Azure Cloud Environment, default to AzurePublicCloud
          environment: AzurePublicCloud
    # - dns01:
    #     route53:
    #       region: centralus
    #       hostedZoneID: xxxxxxxx
    #       accessKeyID: xxxxxx
    #       secretAccessKeySecretRef:
    #         name: aws-secret
    #         key: secret_key
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