using Microsoft.SqlServer;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ScriptsSQL
{
    public static class SqlServerDetector
    {
        private static IEnumerable<string> ObtenerInstancias()
        {
            return new[]
            {
                @"localhost\SQLEXPRESS",
                @"localhost\MSSQLSERVER",

                @".\SQLEXPRESS",
                @".\MSSQLSERVER",

                @"(localdb)\MSSQLLocalDB",
                @"localhost"
            };
        }

        public static Server ObtenerServidorDisponible()
        {
            foreach (var instance in ObtenerInstancias())
            {
                try
                {
                    var conn = new ServerConnection(instance)
                    {
                        LoginSecure = true,
                        ConnectTimeout = 5,
                        EncryptConnection = false,
                        TrustServerCertificate = true
                    };

                    var server = new Server(conn);

                    var _ = server.Databases;

                    return server;
                }
                catch
                {
                }
            }

            throw new Exception("❌ No se encontró ninguna instancia SQL válida para SMO.");
        }
    }
}