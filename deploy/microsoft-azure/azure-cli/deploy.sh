#!/bin/bash
# Bash Menu Script Example
clear
echo "\r\nSearch tools for deployment"
sh check-deployment-tools.sh
sh vars/export-vars.sh
sh check-deployment-vars.sh
PS3='Please enter your choice: '
options=(
    "Create new Resource GROUP in Azure" 
    "Remove Azure Resource GROUP in Azure" 
    "Create new DNS in Azure" 
    "Remove Azure DNS in Azure" 
    "Create AKS cluster"
    "Delete AKS cluster"
    "Full install application in AKS cluster" 
    "Full uninstall application in AKS cluster" 
    "Install analize tools in AKS cluster" 
    "Create main DNS" 
    "Delete main DNS" 
    "Configure main DNS" 
    "Install cert-manager AKS cluster" 
    "Uninstall cert-manager AKS cluster" 
    "Create namespaces for Deployment" 
    "Delete namespaces for Deployment" 
    "Create external-dns for AKS" 
    "Install nginx controller with Public IP" 
    "Uninstall nginx controller with Public IP" 
    "Install test-app" 
    "Uninstall test-app" 
    "Quit")

select opt in "${options[@]}"
do
    case $opt in
            "Create new Resource GROUP in Azure")
            echo "you chose choice $REPLY which is '$opt'"
            sh rc/create-rc.sh
            ;;
            "Remove Azure Resource GROUP in Azure")
            echo "you chose choice $REPLY which is $opt"
            sh rc/delete-rc.sh
            ;;
            "Create new DNS in Azure")
            echo "you chose choice $REPLY which is '$opt'"
            sh dns/create-dns.sh
            ;;
            "Remove Azure DNS in Azure")
            echo "you chose choice $REPLY which is $opt"
            sh dns/delete-dns.sh
            ;;
            "Create AKS cluster")
            echo "you chose choice $REPLY which is $opt"
            sh aks/create-aks.sh
            ;;
            "Delete AKS cluster")
            echo "you chose choice $REPLY which is $opt"
            ;;
            "Full install application in AKS cluster")
            echo "you chose choice $REPLY which is $opt"
            sh rc/create-rc.sh
            sh dns/create-dns.sh
            sh dns/create-dns-primary.sh
            sh aks/create-aks.sh
            sh tools/install.sh
            ;; 
            "Full uninstall application in AKS cluster")
            echo "you chose choice $REPLY which is $opt"
            sh aks/delete-aks.sh
            sh dns/delete-dns.sh
            sh dns/delete-dns-primary.sh
            sh rc/delete-rc.sh
            ;;

            "Quit")
            break
            ;;
        *) echo "invalid option $REPLY";;
    esac
done