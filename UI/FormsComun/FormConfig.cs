using Services.Conifguraciones;
using Services.MultiIdioma;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.FormsComun
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
            LanguageManager.IdiomaCambiado += OnIdiomaCambiado;
        }

        private void OnIdiomaCambiado()
        {
            ActualizarTraducciones();
        }

        private void ActualizarTraducciones()
        {
            Lbl_ModoOscuro.Text = LanguageManager.Traducir("Lbl_ModoOscuro");
            Lbl_titleCambiarClave.Text = LanguageManager.Traducir("Lbl_titleCambiarClave");
            Lbl_titleCambioMail.Text = LanguageManager.Traducir("Lbl_titleCambioMail");
            BtnCambiarClave.Text = LanguageManager.Traducir("BtnCambiarClave");
            Btn_NuevoMail.Text = LanguageManager.Traducir("Btn_NuevoMail");
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            bool oscuro = ThemeManager.ModoOscuro;
            Switch_modoOscuro.Checked = oscuro;
            ThemeManager.ApplyTheme(this, oscuro);

            LanguageManager.CargarUltimoIdioma();
            ActualizarTraducciones();

            ConfigurarTextBox(TxtNuevaClave, "Nueva clave...");
            ConfigurarTextBox(TxtConfirmarClave, "Confirmar clave...");
            ConfigurarTextBox(Txt_NuevoMail, "Nuevo correo...");
        }

        private void ConfigurarTextBox(TextBox textBox, string placeholder)
        {
            textBox.Tag = placeholder;
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Silver;

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Silver;
                }
            };
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            LanguageManager.IdiomaCambiado -= OnIdiomaCambiado;
            base.OnFormClosed(e);
        }

        private void Switch_modoOscuro_CheckedChanged(object sender, EventArgs e)
        {
            bool oscuro = Switch_modoOscuro.Checked;
            ThemeManager.SaveTheme(oscuro);
            ThemeManager.ApplyTheme(this, oscuro);
        }

        private void Btn_NuevoMail_Click(object sender, EventArgs e)
        {
        }

        private void BtnCambiarClave_Click(object sender, EventArgs e)
        {
        }
    }
}