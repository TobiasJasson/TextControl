using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ScriptsSQL
{
    public static class DatabaseInitializer
    {
        private static string _databaseName = "TextControl";

        // posibles instancias a probar
        private static readonly string[] PossibleServers = new[]
        {
            @"(localdb)\MSSQLLocalDB",
            @"localhost\SQLEXPRESS",
            @"localhost"
        };

        public static void Initialize()
        {
            // obtener cadena de conexión base de App.config
            string baseConnection = ConfigurationManager.ConnectionStrings["TextControlDb"].ConnectionString;

            // encontrar un servidor válido
            string workingServer = GetWorkingServer(baseConnection);

            // construir connectionString hacia master
            var builder = new SqlConnectionStringBuilder(baseConnection)
            {
                DataSource = workingServer,
                InitialCatalog = "master"
            };
            string masterConnectionString = builder.ConnectionString;

            // verificar si la base existe
            if (!DatabaseExists(masterConnectionString, _databaseName))
            {
                // leer script SQL
                string pathScript = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScriptsSQL", "TextControlDB.sql");
                if (!File.Exists(pathScript))
                    throw new FileNotFoundException("No se encontró el archivo SQL para inicializar la base de datos.", pathScript);

                string script = File.ReadAllText(pathScript);

                using (SqlConnection conn = new SqlConnection(masterConnectionString))
                {
                    conn.Open();

                    // separar script por líneas
                    var lines = script.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                    StringBuilder sbCommand = new StringBuilder();

                    foreach (var line in lines)
                    {
                        // si es un GO (en mayúsculas y solo GO en la línea), ejecutar el bloque actual
                        if (line.Trim().Equals("GO", StringComparison.OrdinalIgnoreCase))
                        {
                            ExecuteSqlBlock(conn, sbCommand);
                            sbCommand.Clear();
                        }
                        else
                        {
                            sbCommand.AppendLine(line);
                        }
                    }

                    // ejecutar cualquier bloque restante
                    if (sbCommand.Length > 0)
                    {
                        ExecuteSqlBlock(conn, sbCommand);
                    }
                }

                Console.WriteLine($"Base de datos '{_databaseName}' creada correctamente.");
            }
            else
            {
                Console.WriteLine($"Base de datos '{_databaseName}' ya existe. Conexión realizada sin ejecutar scripts.");
            }
        }

        private static void ExecuteSqlBlock(SqlConnection conn, StringBuilder sbCommand)
        {
            if (sbCommand.Length == 0) return;

            // obtener nivel de compatibilidad
            using (SqlCommand cmdLevel = new SqlCommand("SELECT compatibility_level FROM sys.databases WHERE name='master'", conn))
            {
                object result = cmdLevel.ExecuteScalar();
                int level = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 150; // fallback a 150 si algo falla

                // reemplazar COMPATIBILITY_LEVEL = 160
                string commandText = sbCommand.ToString().Replace("COMPATIBILITY_LEVEL = 160", $"COMPATIBILITY_LEVEL = {level}");

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static bool DatabaseExists(string masterConnectionString, string databaseName)
        {
            using (var conn = new SqlConnection(masterConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand($"SELECT db_id('{databaseName}')", conn))
                {
                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value && result != null;
                }
            }
        }

        private static string GetWorkingServer(string baseConnection)
        {
            foreach (var server in PossibleServers)
            {
                try
                {
                    var builder = new SqlConnectionStringBuilder(baseConnection)
                    {
                        DataSource = server,
                        InitialCatalog = "master"
                    };

                    using (var conn = new SqlConnection(builder.ConnectionString))
                    {
                        conn.Open();
                        Console.WriteLine($"✔ Conectado a servidor: {server}");
                        return server;
                    }
                }
                catch
                {
                    Console.WriteLine($"✘ No se pudo conectar a {server}, probando siguiente...");
                }
            }

            throw new Exception("No se encontró ninguna instancia válida de SQL Server en esta máquina.");
        }

        public static string GetConnectionString()
        {
            string baseConnection = ConfigurationManager.ConnectionStrings["TextControlDb"].ConnectionString;
            string workingServer = GetWorkingServer(baseConnection); // probar servidores
            var builder = new SqlConnectionStringBuilder(baseConnection)
            {
                DataSource = workingServer,
                InitialCatalog = _databaseName
            };
            return builder.ConnectionString;
        }
    }
}