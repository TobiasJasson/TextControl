using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Services.MultiIdioma
{
    public static class LanguageManager
    {
        // Diccionario de traducciones cargadas
        private static Dictionary<string, string> _traducciones = new Dictionary<string, string>();

        // Idioma actual
        private static string _idiomaActual = "es-AR";

        // Carpetas y archivos de configuración
        private static readonly string _carpetaApp = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "TextControl");

        private static readonly string _rutaConfig = Path.Combine(_carpetaApp, "lang.config");

        /// <summary>
        /// Evento que notifica cuando se cambia el idioma.
        /// Las pantallas pueden suscribirse a este evento para actualizar sus textos automáticamente.
        /// </summary>
        public static event Action IdiomaCambiado;

        /// <summary>
        /// Carga al iniciar la última preferencia guardada (o el idioma por defecto).
        /// </summary>
        public static void CargarUltimoIdioma()
        {
            try
            {
                if (!Directory.Exists(_carpetaApp))
                    Directory.CreateDirectory(_carpetaApp);

                string idioma = null;
                if (File.Exists(_rutaConfig))
                {
                    idioma = File.ReadAllText(_rutaConfig).Trim();
                }

                if (string.IsNullOrWhiteSpace(idioma))
                    idioma = _idiomaActual;

                CargarIdioma(idioma);
            }
            catch
            {
                // Si algo falla, cargar idioma por defecto
                CargarIdioma(_idiomaActual);
            }
        }

        /// <summary>
        /// Carga el idioma indicado (ej: "es-AR" o "en-US").
        /// </summary>
        public static void CargarIdioma(string codigoIdioma)
        {
            if (string.IsNullOrWhiteSpace(codigoIdioma))
                codigoIdioma = _idiomaActual;

            var archivo = BuscarArchivoRecurso(codigoIdioma);

            if (archivo == null && !string.Equals(codigoIdioma, "es-AR", StringComparison.OrdinalIgnoreCase))
            {
                codigoIdioma = "es-AR";
                archivo = BuscarArchivoRecurso(codigoIdioma);
            }

            if (archivo != null)
            {
                try
                {
                    var json = File.ReadAllText(archivo);
                    _traducciones = JsonConvert.DeserializeObject<Dictionary<string, string>>(json)
                                    ?? new Dictionary<string, string>();
                    _idiomaActual = codigoIdioma;
                    GuardarUltimoIdioma(codigoIdioma);

                    // 🔔 Notificar a las pantallas que el idioma cambió
                    IdiomaCambiado?.Invoke();
                    return;
                }
                catch
                {
                    _traducciones = new Dictionary<string, string>();
                }
            }

            _traducciones = new Dictionary<string, string>();
            _idiomaActual = codigoIdioma;
            IdiomaCambiado?.Invoke(); // notificar incluso si no se pudo cargar archivo
        }

        /// <summary>
        /// Busca el archivo Resources.{codigoIdioma}.json en ubicaciones posibles.
        /// </summary>
        private static string BuscarArchivoRecurso(string codigoIdioma)
        {
            string nombreArchivo = $"Resources.{codigoIdioma}.json";
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            var candidatos = new List<string>
            {
                Path.Combine(baseDir, nombreArchivo),
                Path.Combine(baseDir, "Services", "MultiIdioma", nombreArchivo),
                Path.Combine(Directory.GetCurrentDirectory(), nombreArchivo),
                Path.Combine(baseDir, "..", "..", "..", "Services", "MultiIdioma", nombreArchivo),
                Path.Combine(baseDir, "..", "..", "Services", "MultiIdioma", nombreArchivo),
                Path.Combine(baseDir, "..", "Services", "MultiIdioma", nombreArchivo)
            };

            string dir = baseDir;
            for (int i = 0; i < 6; i++)
            {
                try
                {
                    dir = Path.GetDirectoryName(dir);
                    if (string.IsNullOrEmpty(dir)) break;
                    candidatos.Add(Path.Combine(dir, "Services", "MultiIdioma", nombreArchivo));
                }
                catch { break; }
            }

            foreach (var c in candidatos)
            {
                try
                {
                    var full = Path.GetFullPath(c);
                    if (File.Exists(full))
                        return full;
                }
                catch { }
            }

            // Buscar en carpetas padres
            dir = baseDir;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    dir = Path.GetDirectoryName(dir);
                    if (string.IsNullOrEmpty(dir)) break;
                    var encontrado = Directory.EnumerateFiles(dir, nombreArchivo, SearchOption.AllDirectories).FirstOrDefault();
                    if (!string.IsNullOrEmpty(encontrado)) return encontrado;
                }
                catch { }
            }

            return null;
        }

        /// <summary>
        /// Guarda el último idioma seleccionado.
        /// </summary>
        private static void GuardarUltimoIdioma(string codigoIdioma)
        {
            try
            {
                if (!Directory.Exists(_carpetaApp))
                    Directory.CreateDirectory(_carpetaApp);

                File.WriteAllText(_rutaConfig, codigoIdioma);
            }
            catch
            {
                
            }
        }

        /// <summary>
        /// Cambia el idioma actual forzando su recarga.
        /// </summary>
        public static void EstablecerIdioma(string codigoIdioma) => CargarIdioma(codigoIdioma);

        /// <summary>
        /// Devuelve la traducción correspondiente a la clave indicada.
        /// </summary>
        public static string Traducir(string clave)
        {
            if (_traducciones != null && _traducciones.TryGetValue(clave, out var valor))
                return valor;

            return clave;
        }

        public static string IdiomaActual => _idiomaActual;
    }
}