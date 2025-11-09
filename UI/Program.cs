using DAL.ScriptsSQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connStr = "Server=tcp:yamanote.proxy.rlwy.net,58677;Database=SeguridadTexControl;User ID=sa;Password=Qn~KcDQCsGcl6UCOCtGq3ATncJUrAk2k;TrustServerCertificate=True;Encrypt=False;";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                Console.WriteLine("✅ Conexión exitosa desde C#!");
            }
            DatabaseInitializer.Initialize();
            Console.WriteLine("Base de datos lista.");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());

        }
    }
}
