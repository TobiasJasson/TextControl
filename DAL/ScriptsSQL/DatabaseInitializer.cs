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

            public static void Initialize()
            {
                // Obtener la cadena de conexión de App.config
                string connectionString = ConfigurationManager.ConnectionStrings["TextControlDb"].ConnectionString;

                // Extraer la instancia para conectarse a master
                var builder = new SqlConnectionStringBuilder(connectionString)
                {
                    InitialCatalog = "master"
                };
                string masterConnectionString = builder.ConnectionString;

                // Verificar si la base existe
                if (!DatabaseExists(masterConnectionString, _databaseName))
                {
                    // Leer script SQL
                    string pathScript = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScriptsSQL", "TextControl.sql");
                    if (!File.Exists(pathScript))
                        throw new FileNotFoundException("No se encontró el archivo SQL para inicializar la base de datos.", pathScript);

                    string script = File.ReadAllText(pathScript);

                    using (SqlConnection conn = new SqlConnection(masterConnectionString))
                    {
                        conn.Open();

                        // Separar por "GO" y ejecutar cada lote
                        string[] commands = script.Split(new[] { "\r\nGO\r\n", "\nGO\n", "\r\nGO\n", "\nGO\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var cmdText in commands)
                        {
                            if (string.IsNullOrWhiteSpace(cmdText)) continue;
                            using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    Console.WriteLine($"Base de datos '{_databaseName}' creada correctamente.");
                }
                else
                {
                    Console.WriteLine($"Base de datos '{_databaseName}' ya existe. Conexión realizada sin ejecutar scripts.");
                }
            }

            private static bool DatabaseExists(string masterConnectionString, string databaseName)
            {
                using (var conn = new SqlConnection(masterConnectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand($"SELECT db_id('{databaseName}')", conn))
                    {
                        return cmd.ExecuteScalar() != DBNull.Value;
                    }
                }
            }

            public static string GetConnectionString()
            {
                return ConfigurationManager.ConnectionStrings["TextControlDb"].ConnectionString;
            }
        }
    }

