using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVendasDAO
{
    public sealed class DBConnection
    {
        public MySqlConnection Connection { get; set; }

        private static readonly DBConnection instance = new DBConnection();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static DBConnection()
        {
        }

        private DBConnection()
        {
            string con = "Server=localhost;Database=db_vendas;Uid=root;Pwd=";
            Connection = new MySqlConnection(con);
            Connection.Open();
        }

        public static MySqlConnection Instance
        {
            get
            {
                if (instance.Connection == null || instance.Connection.State != System.Data.ConnectionState.Open)
                {
                    instance.Connection = new DBConnection().Connection;
                }
                return instance.Connection;
            }
        }
    }
}