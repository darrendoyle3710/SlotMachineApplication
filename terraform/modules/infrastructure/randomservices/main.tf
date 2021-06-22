resource "azurerm_app_service" "main" {
    count = 2 

    name                = "${element(var.services, count.index)}-app-service-${var.project_name}"
    location            = var.location
    resource_group_name = var.group_name
    app_service_plan_id = var.app_service_plan_id
}