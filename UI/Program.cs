using DAL.ScriptsSQL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string connStr = ConfigurationManager.ConnectionStrings["SeguridadTextControlDb"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    Console.WriteLine("✅ Conexión local exitosa.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error local: " + ex.Message);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}