resource "azurerm_app_service" "main" {
    name                = "${element(var.services, 3)}-app-service-${var.project_name}"
    location            = var.location
    resource_group_name = var.group_name
    app_service_plan_id = var.app_service_plan_id

    app_settings = {
    "mergeServiceURL" = var.merge_service_url
  }

  connection_string {
    name  = "DefaultConnection"
    type  = "MySql"
    value = var.db_string
  }

  tags = {
    project = "true"
  }
}
