resource "azurerm_mysql_server" "main" {
  name                = "${var.project_name}-mysqlserver"
  location            = var.location
  resource_group_name = var.group_name

  administrator_login          = "darren"
  administrator_login_password = "Pa55w.rd1234"

  sku_name   = "B_Gen5_1"
  storage_mb = 5120
  version    = "5.7"

  auto_grow_enabled                 = false
  ssl_enforcement_enabled           = true

  tags = {
    project = "true"
  }

}

resource "azurerm_mysql_firewall_rule" "client" {
  name                = "client_ip_dd"
  resource_group_name = var.group_name
  server_name         = azurerm_mysql_server.main.name
  start_ip_address    = "78.19.16.33"
  end_ip_address      = "78.19.16.33"

}

resource "azurerm_mysql_firewall_rule" "azure" {
  name                = "azure_services_allowed"
  resource_group_name = var.group_name
  server_name         = azurerm_mysql_server.main.name
  start_ip_address    = "0.0.0.0"
  end_ip_address      = "0.0.0.0"
}

resource "azurerm_mysql_database" "main" {
  name                = "${var.project_name}-db"
  resource_group_name = var.group_name
  server_name         = azurerm_mysql_server.main.name
  charset             = "utf8"
  collation           = "utf8_unicode_ci"
}