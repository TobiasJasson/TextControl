using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.ScriptsSQL
{
    public static class DatabaseInitializer
    {
        private static readonly string[] PossibleServers =
        {
            @"localhost\SQLEXPRESS",
            @"(localdb)\MSSQLLocalDB",
            @"localhost"
        };

        private static string _dbNegocio = "TextControl";
        private static string _dbSeguridad = "SeguridadTexControl";

        public static void Initialize()
        {
            InitializeDatabase(_dbSeguridad, "SeguridadTextControlDB.sql");
            InitializeDatabase(_dbNegocio, "TextControlDB.sql");
        }

        

        public static void InitializeDatabase(string dbName, string scriptFile)
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

        public static void ExecuteSqlScriptOnMaster(string masterConn, string script)
        {
            ExecuteSqlScript(masterConn, script, null);
        }

        private static string DetectAvailableServer()
        {
            foreach (var server in PossibleServers)
            {
                try
                {
                    //if (server.ToLower().Contains("(localdb)"))
                    //    throw new Exception("LocalDB no soporta características requeridas por tu base. Instala SQL Server Express.");

                    using (var conn = new SqlConnection($"Server={server};Database=master;Trusted_Connection=True;"))
                    {
                        conn.Open();
                        return server;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"No se pudo conectar a {server}: {ex.Message}");
                }
            }

            throw new Exception("No se encontró ninguna instancia válida de SQL Server.");
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

        public static void ExecuteSqlScript(string masterConn, string script, string targetDbName)
        {
            using (var conn = new SqlConnection(masterConn))
            {
                conn.Open();

                script = Regex.Replace(script, @"FILENAME\s*=\s*N'[^']+'", "", RegexOptions.IgnoreCase);
                script = script.Replace(", ,", ",");

                var lines = script.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                StringBuilder sb = new StringBuilder();

                foreach (var line in lines)
                {
                    if (line.Trim().Equals("GO", StringComparison.OrdinalIgnoreCase))
                    {
                        ExecuteBlock(conn, sb.ToString(), targetDbName);
                        sb.Clear();
                    }
                    else
                    {
                        sb.AppendLine(line);
                    }
                }

                if (sb.Length > 0)
                    ExecuteBlock(conn, sb.ToString(), targetDbName);
            }
        }

        private static void ExecuteBlock(SqlConnection conn, string blockSql, string targetDbName)
        {
            if (string.IsNullOrWhiteSpace(blockSql)) return;

            string sqlToRun = blockSql;

            if (!string.IsNullOrEmpty(targetDbName))
            {
                var lower = blockSql.ToLowerInvariant();
                if (!lower.Contains("create database") && !lower.Contains("use ["))
                {
                    sqlToRun = $"USE [{targetDbName}]\n{blockSql}";
                }
            }

            using (SqlCommand cmd = new SqlCommand(sqlToRun, conn))
            {
                cmd.CommandTimeout = 600;
                cmd.ExecuteNonQuery();
            }
        }

        public static string GetConnectionString(string dbName)
        {
            var server = DetectAvailableServer();
            return $"Server={server};Database={dbName};Trusted_Connection=True;";
        }

        public static string GetNegocioConnectionString() => GetConnectionString(_dbNegocio);
        public static string GetSeguridadConnectionString() => GetConnectionString(_dbSeguridad);

        public static void DropDatabaseIfExists(string dbName)
        {
            string server = DetectAvailableServer();
            string masterConn = $"Server={server};Database=master;Trusted_Connection=True;";
            using (var conn = new SqlConnection(masterConn))
            {
                conn.Open();
                using (var cmd = new SqlCommand($@"
                    IF EXISTS (SELECT name FROM sys.databases WHERE name = N'{dbName}')
                    BEGIN
                        ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                        DROP DATABASE [{dbName}];
                    END
                    ", conn))
                {
                    cmd.CommandTimeout = 600;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}