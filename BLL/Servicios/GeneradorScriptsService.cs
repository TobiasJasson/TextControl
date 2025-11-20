using DAL.ScriptsSQL;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
using Services.Paths;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View = Microsoft.SqlServer.Management.Smo.View;

namespace BLL.Servicios
{
    public class GeneradorScriptsService
    {
        public void GenerarTodo()
        {
            var server = SqlServerDetector.ObtenerServidorDisponible();

            GenerarScript(server, "TextControl", "TextControlDB.sql");
            GenerarScript(server, "SeguridadTexControl", "SeguridadTextControlDB.sql");
        }


        private void GenerarScript(Server server, string dbName, string archivo)
        {
            string carpeta = ProjectPaths.ObtenerCarpetaScripts();
            Directory.CreateDirectory(carpeta);

            var db = server.Databases[dbName];
            if (db == null)
                throw new Exception($"La base {dbName} no está en el servidor.");

            List<string> scriptFinal = new List<string>();
            scriptFinal.Add($"-- Backup generado {DateTime.Now}");

            var scripterSchema = new Scripter(server)
            {
                Options =
        {
            ScriptDrops = false,
            ScriptSchema = true,
            ScriptData = false,
            IncludeHeaders = true,
            WithDependencies = false,
            SchemaQualify = true,
            DriAll = true,
            Indexes = true,
            Triggers = true
        }
            };

            var urns = db.Tables.Cast<Table>()
                         .Where(t => !t.IsSystemObject)
                         .Select(t => t.Urn)
                         .ToList();

            scriptFinal.AddRange(scripterSchema.Script(urns.ToArray()).Cast<string>());

            string tempFolder = Path.Combine(Path.GetTempPath(), "tex_tmp_" + Guid.NewGuid());
            Directory.CreateDirectory(tempFolder);

            foreach (Table t in db.Tables)
            {
                if (t.IsSystemObject) continue;

                string tempFile = Path.Combine(tempFolder, $"{t.Name}.txt");

                string bcpCmd =
                    $"bcp \"SELECT * FROM {dbName}.dbo.{t.Name}\" queryout \"{tempFile}\" -c -T -S \"{server.Name}\"";

                EjecutarCMD(bcpCmd);

                foreach (string line in File.ReadAllLines(tempFile))
                {
                    string insert = $"INSERT INTO {t.Name} VALUES ({FormatearFila(line)});";
                    scriptFinal.Add(insert);
                }
            }

            File.WriteAllLines(Path.Combine(carpeta, archivo), scriptFinal);

            Directory.Delete(tempFolder, true);
        }

        private void EjecutarCMD(string comando)
        {
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = "/C " + comando;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            proc.WaitForExit();
        }

        private string FormatearFila(string fila)
        {
            var cols = fila.Split('\t');
            return string.Join(", ", cols.Select(c => $"'{c.Replace("'", "''")}'"));
        }
    }
}