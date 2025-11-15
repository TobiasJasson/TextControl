using DAL.ScriptsSQL;
using Services.Conifguraciones;
using System;
using System.Collections.Generic;
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
            DatabaseInitializer.Initialize();
            Console.WriteLine("Base de datos lista.");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ThemeManager.LoadTheme();
            Application.Run(new Login());

        }
    }
}
