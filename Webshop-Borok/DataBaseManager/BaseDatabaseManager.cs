using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Webshop_Borok.DataBaseManager
{
    public class BaseDatabaseManager
    {
        protected BaseDatabaseManager() { }

        public static MySqlConnection connection
        {
            get
            {
                MySqlConnection connection = new MySqlConnection();
                string connectionString = "SERVER=192.168.31.153;" + "DATABASE=webaruhaz;" + "UID=root;" + "PASSWORD=password;" + "SSL MODE=none;";
                connection.ConnectionString = connectionString;
                return connection;
            }
        }
    }
}