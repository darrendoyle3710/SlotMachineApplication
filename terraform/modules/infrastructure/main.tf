terraform {
    required_providers {
        azurerm = {
            source  = "hashicorp/azurerm"
            version = "~> 2.46.0"
        }
    }
}

provider "azurerm" {
    features {}
}

resource "azurerm_resource_group" "main" {
    name     = "${var.project_name}-rg"
    location = var.location

    tags = {
    project = "true"
  }
}

module "appserviceplan" {
    source       = "./appserviceplan"
    project_name = var.project_name
    group_name   = azurerm_resource_group.main.name
    location     = var.location

}
module "randomservices" {
    source       = "./randomservices"
    project_name = var.project_name
    group_name   = azurerm_resource_group.main.name
    location     = var.location
    services     = var.services
    app_service_plan_id = module.appserviceplan.app_service_plan_id
}
module "mergeservice" {
    source       = "./mergeservice"
    project_name = var.project_name
    group_name   = azurerm_resource_group.main.name
    location     = var.location
    services     = var.services
    app_service_plan_id = module.appserviceplan.app_service_plan_id
    random_services_url = module.randomservices.random_services_url
    
}
module "database" {
    source       = "./database"
    project_name = var.project_name
    group_name   = azurerm_resource_group.main.name
    location     = var.location
}
module "frontendservice" {
    source       = "./frontendservice"
    project_name = var.project_name
    group_name   = azurerm_resource_group.main.name
    location     = var.location
    services     = var.services
    app_service_plan_id = module.appserviceplan.app_service_plan_id
    merge_service_url = module.mergeservice.merge_service_url
    db_string = module.database.db_string
}