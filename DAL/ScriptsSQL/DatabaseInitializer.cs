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
        private static readonly string[] PossibleServers =
        {
            @"(localdb)\MSSQLLocalDB",
            @"localhost\SQLEXPRESS",
            @"localhost"
        };

        private static string _dbNegocio = "TextControl";
        private static string _dbSeguridad = "SeguridadTexControl";

        public static void Initialize()
        {
            InitializeDatabase(_dbNegocio, "TextControlDB.sql");
            InitializeDatabase(_dbSeguridad, "SeguridadTextControlDB.sql");
        }

        private static void InitializeDatabase(string dbName, string scriptFile)
        {
            string workingServer = DetectAvailableServer();

            var masterConn = $"Server={workingServer};Database=master;Trusted_Connection=True;";

            if (!DatabaseExists(masterConn, dbName))
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScriptsSQL", scriptFile);
                if (!File.Exists(path))
                    throw new FileNotFoundException($"No se encontró el script {scriptFile}", path);

                string script = File.ReadAllText(path);
                ExecuteSqlScript(masterConn, script, dbName);
                Console.WriteLine($"✔ Base de datos '{dbName}' creada correctamente en {workingServer}.");
            }
            else
            {
                Console.WriteLine($"ℹ Base de datos '{dbName}' ya existe en {workingServer}, se omite creación.");
            }
        }

        private static string DetectAvailableServer()
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

        private static bool DatabaseExists(string masterConn, string dbName)
        {
            using (var conn = new SqlConnection(masterConn))
            {
                conn.Open();
                using (var cmd = new SqlCommand($"SELECT db_id('{dbName}')", conn))
                {
                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value && result != null;
                }
            }
        }

        private static void ExecuteSqlScript(string masterConn, string script, string dbName)
        {
            using (var conn = new SqlConnection(masterConn))
            {
                conn.Open();

                script = System.Text.RegularExpressions.Regex.Replace(
                    script,
                    @"FILENAME\s*=\s*N'[^']+'",
                    "",
                    System.Text.RegularExpressions.RegexOptions.IgnoreCase
                );
                script = script.Replace(", ,", ",");

                var lines = script.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                StringBuilder sb = new StringBuilder();

                foreach (var line in lines)
                {
                    if (line.Trim().Equals("GO", StringComparison.OrdinalIgnoreCase))
                    {
                        ExecuteBlock(conn, sb, dbName);
                        sb.Clear();
                    }
                    else
                    {
                        sb.AppendLine(line);
                    }
                }

                if (sb.Length > 0)
                    ExecuteBlock(conn, sb, dbName);
            }
        }

        private static void ExecuteBlock(SqlConnection conn, StringBuilder sb, string dbName)
        {
            if (sb.Length == 0) return;
            using (SqlCommand cmd = new SqlCommand(sb.ToString(), conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static string GetConnectionString()
        {
            string server = DetectAvailableServer();
            return $"Server={server};Database={_dbNegocio};Trusted_Connection=True;";
        }

        public static string GetConnectionStringSeguridad()
        {
            string server = DetectAvailableServer();
            return $"Server={server};Database={_dbSeguridad};Trusted_Connection=True;";
        }
    }
}