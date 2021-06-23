resource "azurerm_app_service" "main" {
    name                = "${element(var.services, 2)}-app-service-${var.project_name}"
    location            = var.location
    resource_group_name = var.group_name
    app_service_plan_id = var.app_service_plan_id

    app_settings = {
     "animalServiceURL" = "${var.random_services_url[0]}"
     "numberServiceURL" = "${var.random_services_url[1]}"
  }

  tags = {
    project = "true"
  }
}
