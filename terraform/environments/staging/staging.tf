variable "project_name" {}
variable "location" {}
variable "services" {}


terraform {
    required_providers {
        azureri = {
            source  = "hashicorp/azurerm"
            version = "~> 2.46.0"
        }
    }
}

provider "azurerm" {
    features {}
}

module "infrastructure" {
    source       = "../../modules/infrastructure"
    project_name = var.project_name
    location     = var.location
    services = var.services
}