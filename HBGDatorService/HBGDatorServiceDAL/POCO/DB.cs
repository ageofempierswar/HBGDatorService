using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace HBGDatorServiceDAL.POCO
{
    public class DB
    {
        public static string ConnectionString
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["HBGDatorServiceDB"].ToString();
                var newConnectionString = new SqlConnectionStringBuilder(connectionString);
                newConnectionString.ApplicationName = ApplicationName ?? newConnectionString.ApplicationName;
                newConnectionString.ConnectTimeout = (ConnectionTimeout > 0)
                    ? ConnectionTimeout : newConnectionString.ConnectTimeout;

                return connectionString.ToString();
            }
        }
        public static int ConnectionTimeout { get; set; }
        public static string ApplicationName { get; set; }

        public static SqlConnection GetSqlConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
