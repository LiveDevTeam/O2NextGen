
# initialize terraform Azure modules
terraform init

# delete the infra
terraform destroy -auto-approve

# cleanup files
rm terraform.tfstate
rm terraform.tfstate.backup
rm tfplan
rm tfplan.json
rm -r .terraform/