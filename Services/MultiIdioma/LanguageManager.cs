using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Services.MultiIdioma
{
    public static class LanguageManager
    {
        private static Dictionary<string, string> _translations = new Dictionary<string, string>();
        private static string _currentLanguage = "es-AR";
        private static readonly string _appFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "TextControl");
        private static readonly string _configFilePath = Path.Combine(_appFolder, "lang.config");

        /// <summary>
        /// Carga al iniciar la última preferencia guardada (o el idioma por defecto).
        /// </summary>
        public static void LoadLastLanguage()
        {
            try
            {
                if (!Directory.Exists(_appFolder)) Directory.CreateDirectory(_appFolder);

                string lang = null;
                if (File.Exists(_configFilePath))
                {
                    lang = File.ReadAllText(_configFilePath).Trim();
                }

                if (string.IsNullOrWhiteSpace(lang))
                {
                    lang = _currentLanguage;
                }

                LoadLanguage(lang);
            }
            catch
            {
                // Si algo falla, cargar el idioma por defecto
                LoadLanguage(_currentLanguage);
            }
        }

        /// <summary>
        /// Fuerza la carga del idioma indicado (ej: "es-AR" o "en-EEUU").
        /// </summary>
        public static void LoadLanguage(string langCode)
        {
            if (string.IsNullOrWhiteSpace(langCode)) langCode = _currentLanguage;

            // Intentar encontrar el archivo para el idioma pedido
            var file = FindResourceFile(langCode);

            // Si no se encuentra, intentar con el idioma por defecto
            if (file == null && !string.Equals(langCode, "es-AR", StringComparison.OrdinalIgnoreCase))
            {
                langCode = "es-AR";
                file = FindResourceFile(langCode);
            }

            if (file != null)
            {
                try
                {
                    var json = File.ReadAllText(file);
                    _translations = JsonConvert.DeserializeObject<Dictionary<string, string>>(json)
                                    ?? new Dictionary<string, string>();
                    _currentLanguage = langCode;
                    SaveLastLanguage(langCode);
                    return;
                }
                catch
                {
                    // si falla la lectura/json -> dejar translations vacías (fallback)
                    _translations = new Dictionary<string, string>();
                }
            }

            // Si no hay archivo válido, aseguramos que _translations no sea null
            _translations = _translations ?? new Dictionary<string, string>();
            _currentLanguage = langCode;
        }

        /// <summary>
        /// Busca el archivo Resources.{langCode}.json en varios lugares razonables.
        /// Devuelve la ruta absoluta si lo encuentra, o null.
        /// </summary>
        private static string FindResourceFile(string langCode)
        {
            string fileName = $"Resources.{langCode}.json";
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var candidates = new List<string>
            {
                Path.Combine(baseDir, fileName),
                Path.Combine(baseDir, "Services", "MultiIdioma", fileName),
                Path.Combine(Directory.GetCurrentDirectory(), fileName),
                // rutas relativas comunes (subir desde bin a la raíz del proyecto)
                Path.Combine(baseDir, "..", "..", "..", "Services", "MultiIdioma", fileName),
                Path.Combine(baseDir, "..", "..", "Services", "MultiIdioma", fileName),
                Path.Combine(baseDir, "..", "Services", "MultiIdioma", fileName)
            };

            // Añadir búsquedas subiendo varios niveles y buscando Services\MultiIdioma
            string dir = baseDir;
            for (int i = 0; i < 6; i++)
            {
                try
                {
                    dir = Path.GetDirectoryName(dir);
                    if (string.IsNullOrEmpty(dir)) break;
                    candidates.Add(Path.Combine(dir, "Services", "MultiIdioma", fileName));
                }
                catch { break; }
            }

            foreach (var c in candidates)
            {
                try
                {
                    var full = Path.GetFullPath(c);
                    if (File.Exists(full)) return full;
                }
                catch { }
            }

            // Último recurso: intentar buscar (SearchOption.AllDirectories) en carpetas padres hasta 3 niveles
            dir = baseDir;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    dir = Path.GetDirectoryName(dir);
                    if (string.IsNullOrEmpty(dir)) break;
                    var found = Directory.EnumerateFiles(dir, fileName, SearchOption.AllDirectories).FirstOrDefault();
                    if (!string.IsNullOrEmpty(found)) return found;
                }
                catch { }
            }

            return null;
        }

        private static void SaveLastLanguage(string langCode)
        {
            try
            {
                if (!Directory.Exists(_appFolder)) Directory.CreateDirectory(_appFolder);
                File.WriteAllText(_configFilePath, langCode);
            }
            catch
            {
                // no hacemos nada si no se puede guardar; la app sigue funcionando con la selección en memoria
            }
        }

        public static void SetLanguage(string langCode) => LoadLanguage(langCode);

        public static string Translate(string key)
        {
            if (_translations != null && _translations.TryGetValue(key, out var value))
                return value;
            return key;
        }

        public static string CurrentLanguage => _currentLanguage;
    }
}
