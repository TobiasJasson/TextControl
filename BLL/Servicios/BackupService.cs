using DAL.ScriptsSQL;
using Services.Paths;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.Servicios
{
    public class BackupService
    {
        private readonly GeneradorScriptsService _generador = new GeneradorScriptsService();

        public void GenerarBackupInterno()
        {
            _generador.GenerarTodo();
        }

        public void ExportarBackupZip()
        {
            string carpeta = ProjectPaths.ObtenerCarpetaScripts();
            string fileA = Path.Combine(carpeta, "TextControlDB.sql");
            string fileB = Path.Combine(carpeta, "SeguridadTextControlDB.sql");

            if (!File.Exists(fileA) || !File.Exists(fileB))
                throw new FileNotFoundException("No se encontraron los archivos internos .sql. Generá el backup interno primero.");

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Zip files (*.zip)|*.zip";
                sfd.FileName = $"Backup_TextControl_{DateTime.Now:yyyyMMdd_HHmmss}.zip";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                using (var zip = ZipFile.Open(sfd.FileName, ZipArchiveMode.Create))
                {
                    zip.CreateEntryFromFile(fileA, Path.GetFileName(fileA));
                    zip.CreateEntryFromFile(fileB, Path.GetFileName(fileB));
                }

                MessageBox.Show("Backup exportado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ImportarBackupUsuario()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Backup zip (*.zip)|*.zip|SQL script (*.sql)|*.sql";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() != DialogResult.OK) return;

                string selected = ofd.FileName;
                string carpeta = ProjectPaths.ObtenerCarpetaScripts();
                Directory.CreateDirectory(carpeta);

                if (selected.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                {
                    string temp = Path.Combine(Path.GetTempPath(), "texcontrol_backup_" + Guid.NewGuid().ToString("N"));
                    Directory.CreateDirectory(temp);
                    ZipFile.ExtractToDirectory(selected, temp);

                    var fText = Directory.GetFiles(temp, "TextControlDB*.sql", SearchOption.AllDirectories).FirstOrDefault()
                                ?? Directory.GetFiles(temp, "TextControl*.sql", SearchOption.AllDirectories).FirstOrDefault();

                    var fSeg = Directory.GetFiles(temp, "SeguridadTextControl*.sql", SearchOption.AllDirectories).FirstOrDefault()
                               ?? Directory.GetFiles(temp, "SeguridadTexControl*.sql", SearchOption.AllDirectories).FirstOrDefault()
                               ?? Directory.GetFiles(temp, "Seguridad*.sql", SearchOption.AllDirectories).FirstOrDefault();

                    if (fText == null && fSeg == null)
                        throw new Exception("El zip no contiene los archivos SQL esperados.");

                    if (fText != null) File.Copy(fText, Path.Combine(carpeta, "TextControlDB.sql"), true);
                    if (fSeg != null) File.Copy(fSeg, Path.Combine(carpeta, "SeguridadTextControlDB.sql"), true);

                    RestaurarDesdeArchivosInternos();

                    Directory.Delete(temp, true);
                }
                else if (selected.EndsWith(".sql", StringComparison.OrdinalIgnoreCase))
                {
                    string content = File.ReadAllText(selected);

                    var markers = new[] { "create database [textcontrol", "create database [seguridad", "create database [seguridadtexcontrol" };
                    string lc = content.ToLowerInvariant();

                    string carpetaDestino = carpeta;

                    if (lc.Contains("create database [textcontrol") && lc.Contains("create database [seguridad"))
                    {
                        int posText = lc.IndexOf("create database [textcontrol");
                        int posSeg = lc.IndexOf("create database [seguridad");
                        if (posText < posSeg)
                        {
                            string partText = content.Substring(posText, posSeg - posText);
                            string partSeg = content.Substring(posSeg);
                            File.WriteAllText(Path.Combine(carpetaDestino, "TextControlDB.sql"), partText);
                            File.WriteAllText(Path.Combine(carpetaDestino, "SeguridadTextControlDB.sql"), partSeg);
                        }
                        else
                        {
                            string partSeg = content.Substring(posSeg, posText - posSeg);
                            string partText = content.Substring(posText);
                            File.WriteAllText(Path.Combine(carpetaDestino, "TextControlDB.sql"), partText);
                            File.WriteAllText(Path.Combine(carpetaDestino, "SeguridadTextControlDB.sql"), partSeg);
                        }
                    }
                    else
                    {
                        File.Copy(selected, Path.Combine(carpetaDestino, "TextControlDB.sql"), true);
                        File.Copy(selected, Path.Combine(carpetaDestino, "SeguridadTextControlDB.sql"), true);
                    }

                    RestaurarDesdeArchivosInternos();
                }

                MessageBox.Show("Importación finalizada.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void RestaurarDesdeArchivosInternos()
        {
            string carpeta = ProjectPaths.ObtenerCarpetaScripts();
            string fileText = Path.Combine(carpeta, "TextControlDB.sql");
            string fileSeg = Path.Combine(carpeta, "SeguridadTextControlDB.sql");

            if (!File.Exists(fileText) || !File.Exists(fileSeg))
                throw new FileNotFoundException("Faltan archivos SQL internos para restaurar. Ejecuta GenerarBackupInterno o importa un backup primero.");

            // Primero: Borrar las bases si existen (limpia datos sucios)
            DatabaseInitializer.DropDatabaseIfExists("TextControl");
            DatabaseInitializer.DropDatabaseIfExists("SeguridadTexControl"); 

            string masterServer = null;
            foreach (var s in new[] { @"(localdb)\MSSQLLocalDB", @"localhost\SQLEXPRESS", @"localhost" })
            {
                try
                {
                    using (var conn = new System.Data.SqlClient.SqlConnection($"Server={s};Database=master;Trusted_Connection=True;"))
                    {
                        conn.Open();
                        masterServer = s;
                        break;
                    }
                }
                catch { }
            }
            if (masterServer == null) throw new Exception("No se encontró instancia SQL para restaurar.");

            string masterConn = $"Server={masterServer};Database=master;Trusted_Connection=True;";

            string scriptSeg = File.ReadAllText(fileSeg);
            DatabaseInitializer.ExecuteSqlScriptOnMaster(masterConn, scriptSeg);

            string scriptText = File.ReadAllText(fileText);
            DatabaseInitializer.ExecuteSqlScriptOnMaster(masterConn, scriptText);
        }
    }
}