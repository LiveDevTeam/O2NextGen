# make sure terraform CLI is installed
terraform

# format the tf files
terraform fmt

# initialize terraform Azure modules
terraform init

# validate the template
terraform validate

# plan and save the infra changes into tfplan file
terraform plan -out tfplan -var-file=./dev/dev.tfvars

# show the tfplan file
# terraform show -json tfplan -var-file=./dev/dev.tfvars
# terraform show -json tfplan -var-file=./dev/dev.tfvars>> tfplan.json

# # Format tfplan.json file
# terraform show -json tfplan -var-file=./dev/dev.tfvars| jq '.' > tfplan.json

# # show only the changes
# cat tfplan.json | jq -r '(.resource_changes[] | [.change.actions[], .type, .change.after.name]) | @tsv'
# cat tfplan.json | jq '[.resource_changes[] | {type: .type, name: .change.after.name, actions: .change.actions[]}]' 
