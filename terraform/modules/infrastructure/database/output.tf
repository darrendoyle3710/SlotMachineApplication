output "db_string" {
    value = "Server=${azurerm_mysql_server.main.name}.mysql.database.azure.com; Port=3306; Database=${azurerm_mysql_database.main.name}; Uid=${azurerm_mysql_server.main.administrator_login}@${azurerm_mysql_server.main.name}; Pwd=${azurerm_mysql_server.main.administrator_login_password}; SslMode=Preferred; ConvertZeroDateTime=True;"
}