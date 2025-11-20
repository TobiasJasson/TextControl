using BLL;
using BLL.Servicios;
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
using Microsoft.SqlServer;

namespace UI.FormsComun
{
    public partial class FormConfig : Form
    {
        private UsuarioService _usuarioService;
        private EmpleadoService _empleadoService;
        private readonly BackupService _backupService = new BackupService();


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
            TxtNuevaClave.Text = LanguageManager.Traducir("TxtNuevaClave");
            TxtConfirmarClave.Text = LanguageManager.Traducir("TxtConfirmarClave");
            Txt_NuevoMail.Text = LanguageManager.Traducir("Txt_NuevoMail");
            Lbl_NameUser.Text = LanguageManager.Traducir("Lbl_NameUser");
            Txt_NameUser.Text = LanguageManager.Traducir("Txt_NameUser");
            Btn_NameUser.Text = LanguageManager.Traducir("BtnCambiarNameUser");
        }

        private async void FormConfig_Load(object sender, EventArgs e)
        {

            await InicializarAsync();

            bool oscuro = ThemeManager.ModoOscuro;
            Switch_modoOscuro.Checked = oscuro;
            ThemeManager.ApplyTheme(this, oscuro);

            //LanguageManager.CargarUltimoIdioma();
            //ActualizarTraducciones();

            //ConfigurarTextBox(TxtNuevaClave, "Nueva clave...");
            //ConfigurarTextBox(TxtConfirmarClave, "Confirmar clave...");
            //ConfigurarTextBox(Txt_NuevoMail, "Nuevo correo...");
        }

        private async Task InicializarAsync()
        {
            await Task.Run(() =>
            {
                _usuarioService = new UsuarioService();
                _empleadoService = new EmpleadoService();
            });


            // Luego seguís con el resto sin bloquear
            bool oscuro = ThemeManager.ModoOscuro;
            Switch_modoOscuro.Checked = oscuro;
            ThemeManager.ApplyTheme(this, oscuro);
            LanguageManager.CargarUltimoIdioma();
            ActualizarTraducciones();
            ConfigurarTextBox(TxtNuevaClave, "Nueva clave...", true);
            ConfigurarTextBox(TxtConfirmarClave, "Confirmar clave...", true);
            ConfigurarTextBox(Txt_NuevoMail, "Nuevo correo...");
        }

        private void ConfigurarTextBox(TextBox textBox, string placeholder, bool esPassword = false)
        {
            textBox.Tag = Tuple.Create(placeholder, esPassword);

            SetPlaceholder(textBox);

            textBox.Enter += (s, e) =>
            {
                var tup = (Tuple<string, bool>)textBox.Tag;
                string ph = tup.Item1;
                bool isPwd = tup.Item2;

                if (textBox.Text == ph)
                {
                    textBox.Text = "";
                    textBox.ForeColor = ThemeManager.ModoOscuro ? Color.White : Color.Black;
                    if (isPwd) textBox.UseSystemPasswordChar = true;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                    SetPlaceholder(textBox);
            };
        }

        private void SetPlaceholder(TextBox textBox)
        {
            var tup = (Tuple<string, bool>)textBox.Tag;
            string ph = tup.Item1;
            bool isPwd = tup.Item2;

            textBox.Text = ph;
            textBox.ForeColor = Color.Silver;
            textBox.UseSystemPasswordChar = false;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            LanguageManager.IdiomaCambiado -= OnIdiomaCambiado;
            base.OnFormClosed(e);
        }


        private void Switch_modoOscuro_CheckedChanged(object sender, EventArgs e)
        {
            bool nuevoEstado = Switch_modoOscuro.Checked;
            ThemeManager.SaveTheme(nuevoEstado);
            ThemeManager.ApplyTheme(this, nuevoEstado);
        }

        private void Btn_NuevoMail_Click(object sender, EventArgs e)
        {
            string nuevoMail = Txt_NuevoMail.Text.Trim();

            if (string.IsNullOrEmpty(nuevoMail) || nuevoMail == "Nuevo correo...")
            {
                MessageBox.Show(LanguageManager.Traducir("Config_MensajeMailVacio"),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(nuevoMail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show(LanguageManager.Traducir("Config_MensajeMailInvalido"),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idEmpleado = SessionManager.Instance.EmpleadoActual.IdEmpleado;

            bool exito = _empleadoService.CambiarGmail(idEmpleado, nuevoMail);

            MessageBox.Show(exito
                ? LanguageManager.Traducir("Config_MensajeMailCambiado")
                : LanguageManager.Traducir("Config_MensajeErrorMail"),
                            "Configuración", MessageBoxButtons.OK,
                            exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (exito)
            {
                SetPlaceholder(Txt_NuevoMail);
                Txt_NuevoMail.ForeColor = Color.Silver;
            }
        }

        private void BtnCambiarClave_Click_1(object sender, EventArgs e)
        {
            string nuevaClave = TxtNuevaClave.Text.Trim();
            string confirmarClave = TxtConfirmarClave.Text.Trim();

            if (string.IsNullOrEmpty(nuevaClave) || nuevaClave == "Nueva clave...")
            {
                MessageBox.Show(LanguageManager.Traducir("Config_MensajeClaveVacia"),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nuevaClave != confirmarClave)
            {
                MessageBox.Show(LanguageManager.Traducir("Config_MensajeClavesNoCoinciden"),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = SessionManager.Instance.UsuarioActual.UserName;
            bool exito = _usuarioService.CambiarClave(username, nuevaClave);

            MessageBox.Show(exito
                ? LanguageManager.Traducir("Config_MensajeClaveCambiada")
                : LanguageManager.Traducir("Config_MensajeErrorClave"),
                "Configuración", MessageBoxButtons.OK,
                exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (exito)
            {
                SetPlaceholder(TxtNuevaClave);
                SetPlaceholder(TxtConfirmarClave);
                TxtNuevaClave.ForeColor = TxtConfirmarClave.ForeColor = Color.Silver;
            }
        }

        private void Lbl_titleCambiarClave_Click(object sender, EventArgs e)
        {

        }

        private void TxtConfirmarClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_NameUser_Click(object sender, EventArgs e)
        {
            string nameUser = Txt_NameUser.Text.Trim();

            if (string.IsNullOrEmpty(nameUser) || nameUser == LanguageManager.Traducir("Txt_NameUser"))
            {
                MessageBox.Show(LanguageManager.Traducir("Config_MensajeNameUserVacio"),
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int idUser = SessionManager.Instance.UsuarioActual.IdUsuario;
            bool exito = _usuarioService.CambiarNameUser(nameUser, idUser);

            MessageBox.Show(exito
                ? LanguageManager.Traducir("Config_MensajeClaveCambiada")
                : LanguageManager.Traducir("Config_MensajeErrorClave"),
                "Configuración", MessageBoxButtons.OK,
                exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (exito)
            {
                SetPlaceholder(Txt_NameUser);
            }
        }

        


        private void Btn_ImportarBackUP_Click(object sender, EventArgs e)
        {
            try
            {
                _backupService.ImportarBackupUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importando: " + ex.Message);
            }
        }

        private void Btn_GenerarBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                _backupService.GenerarBackupInterno();
                MessageBox.Show("Backup interno generado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_RestaurarBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                var confirm = MessageBox.Show("Esto borrará las bases actuales y las recreará desde los scripts internos. ¿Continuar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                _backupService.RestaurarDesdeArchivosInternos();
                MessageBox.Show("Restauración finalizada.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error restaurando: " + ex.Message);
            }
        }

        private void Btn_ExportarBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                _backupService.GenerarBackupInterno();
                _backupService.ExportarBackupZip();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exportando: " + ex.Message);
            }
        }

        private void Lbl_NameUser_Click(object sender, EventArgs e)
        {

        }

        private void Txt_NameUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}