using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Paths
{
    public static class ProjectPaths
    {
        public static string ObtenerCarpetaScripts()
        {
            string root = AppDomain.CurrentDomain.BaseDirectory;

            string carpeta = Path.Combine(root, @"..\..\..\DAL\ScriptsSQL");

            return Path.GetFullPath(carpeta);
        }
    }
}