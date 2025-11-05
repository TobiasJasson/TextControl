using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services.Conifguraciones
{
    public static class ThemeManager
    {
        private static readonly string _appFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "TextControl");
        private static readonly string _configFilePath = Path.Combine(_appFolder, "theme.config");

        private static bool _modoOscuro = false;

        public static bool ModoOscuro => _modoOscuro;

        public static void LoadTheme()
        {
            try
            {
                if (!Directory.Exists(_appFolder)) Directory.CreateDirectory(_appFolder);

                if (File.Exists(_configFilePath))
                {
                    string text = File.ReadAllText(_configFilePath).Trim();
                    if (bool.TryParse(text, out bool value))
                        _modoOscuro = value;
                }
            }
            catch
            {
                _modoOscuro = false; // valor por defecto
            }
        }

        public static void SaveTheme(bool oscuro)
        {
            try
            {
                if (!Directory.Exists(_appFolder)) Directory.CreateDirectory(_appFolder);
                File.WriteAllText(_configFilePath, oscuro.ToString());
                _modoOscuro = oscuro;
            }
            catch
            {
                // Si falla, no hacemos nada, solo no se guarda el cambio
            }
        }

        public static void ApplyTheme(Form form, bool oscuro)
        {
            if (form == null) return;

            form.BackColor = oscuro ? Color.FromArgb(18, 18, 18) : Color.White;
            CambiarColorControles(form.Controls, oscuro);
        }

        private static void CambiarColorControles(Control.ControlCollection controles, bool oscuro)
        {
            Color colorTexto = oscuro ? Color.Silver : Color.Black;
            Color colorFondo = oscuro ? Color.FromArgb(30, 30, 30) : Color.White;

            foreach (Control ctrl in controles)
            {
                if (ctrl is Label || ctrl is Button || ctrl is CheckBox)
                {
                    ctrl.ForeColor = oscuro ? Color.Silver : Color.Black;
                    ctrl.BackColor = colorFondo;
                }
                else if (ctrl is TextBox txt)
                {
                    string placeholder = null;
                    bool tienePlaceholderInfo = false;

                    Tuple<string, bool> tup = null;

                    if (txt.Tag is Tuple<string, bool> tempTup)
                    {
                        placeholder = tempTup.Item1;
                        tienePlaceholderInfo = true;
                        tup = tempTup; 
                    }

                    bool esPlaceholder = tienePlaceholderInfo && txt.Text == placeholder;

                    txt.BackColor = oscuro ? Color.FromArgb(40, 40, 40) : Color.WhiteSmoke;
                    txt.BorderStyle = BorderStyle.FixedSingle;

                    if (esPlaceholder)
                    {
                        txt.ForeColor = Color.Silver;
                        if (tup != null && tup.Item2)
                            txt.UseSystemPasswordChar = false;
                    }
                    else
                    {
                        txt.ForeColor = oscuro ? Color.White : Color.Black;
                        if (tup != null && tup.Item2)
                            txt.UseSystemPasswordChar = true;
                    }
                }
                else if (ctrl.HasChildren)
                {
                    CambiarColorControles(ctrl.Controls, oscuro);
                }
            }
        }
    }
}