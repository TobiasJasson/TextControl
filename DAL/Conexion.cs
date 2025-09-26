using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public class Conexion
    {
        private readonly string _connectionString;

        public Conexion()
        {
            // Lee la cadena de conexión del App.config (ejecutable)
            //_connectionString = ConfigurationManager.ConnectionStrings["TextControlDb"].ConnectionString;
            _connectionString = DAL.ScriptsSQL.DatabaseInitializer.GetConnectionString();
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
