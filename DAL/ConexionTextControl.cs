using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public class ConexionTextControl
    {
        private readonly string _connectionString;

        private static readonly string[] PossibleServers =
        {
            @"(localdb)\MSSQLLocalDB",
            @"localhost\SQLEXPRESS",
            @"localhost"
        };

        public ConexionTextControl()
        {
            // Detecta un servidor disponible
            string server = DetectAvailableServer();

            // Construye la cadena de conexión dinámicamente
            _connectionString = $"Server={server};Database=TextControl;Trusted_Connection=True;";
        }

        private string DetectAvailableServer()
        {
            foreach (var server in PossibleServers)
            {
                try
                {
                    using (var conn = new SqlConnection($"Server={server};Database=master;Trusted_Connection=True;"))
                    {
                        conn.Open();
                        Console.WriteLine($"✔ Servidor disponible: {server}");
                        return server;
                    }
                }
                catch
                {
                    Console.WriteLine($"✘ No se pudo conectar a {server}, probando siguiente...");
                }
            }

            throw new Exception("❌ No se encontró ninguna instancia válida de SQL Server.");
        }

        public SqlConnection GetConnection()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn;
        }

        public bool ProbarConexion()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de conexión: " + ex.Message);
                return false;
            }
        }
    }
}