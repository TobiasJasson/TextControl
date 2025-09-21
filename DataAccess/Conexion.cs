using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Conexion
    {
        private readonly string _connectionString;

        public Conexion()
        {
            // Lee la cadena de conexión del App.config (ejecutable)
            _connectionString = ConfigurationManager.ConnectionStrings["TextControlDb"].ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
