resource "azurerm_app_service_plan" "main" {
  name                = "${var.project_name}_azurerm_app_service_plan"
  location            = var.location
  resource_group_name = var.group_name

  sku {
    tier = "Basic"
    size = "B1"
  }
}