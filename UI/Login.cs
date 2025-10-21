using BLL;
using BLL.Servicios;
using DomainModel;
using Services.MultiIdioma;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.Admin;
using Services.EmpleadosForms;
using System;


namespace UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Login_Load(object sender, EventArgs e)
        {
            LanguageManager.CargarUltimoIdioma();
            ApplyTranslations();

            // Placeholder fijo (no traducido dinámicamente)
            ConfigurarTextBox(TxtNameUser, "Usuario", false);
            ConfigurarTextBox(TxtPassword, "Contraseña", true);
        }

        private void ConfigurarTextBox(TextBox textBox, string placeholder, bool esPassword)
        {
            textBox.Tag = new Tuple<string, bool>(placeholder, esPassword);
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Silver;
            textBox.UseSystemPasswordChar = false;

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Silver;
                    textBox.UseSystemPasswordChar = esPassword;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Silver;
                    textBox.UseSystemPasswordChar = false;
                }
            };
        }

        private void ApplyTranslations()
        {
            lblTitulo.Text = LanguageManager.Traducir("Login_Titulo");
            Btn_Ingresar.Text = LanguageManager.Traducir("Login_BotonIngresar");
            LiL_RecuperarPass.Text = LanguageManager.Traducir("Login_OlvidoClave");
            ChBox_MostrarContraseña.Text = LanguageManager.Traducir("Login_MostrarContraseña");
            BtnCambiarIdioma.Text = LanguageManager.Traducir("Login_BotonIdioma");
        }

        private void BtnCambiarIdioma_Click(object sender, EventArgs e)
        {
            string nuevoIdioma = LanguageManager.IdiomaActual == "es-AR" ? "en-EEUU" : "es-AR";
            LanguageManager.CargarIdioma(nuevoIdioma);
            ApplyTranslations();
        }

        private void ChBox_MostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            var tagData = (Tuple<string, bool>)TxtPassword.Tag;
            bool esPassword = tagData.Item2;

            if (TxtPassword.Text == tagData.Item1)
            {
                TxtPassword.UseSystemPasswordChar = false; // si está mostrando placeholder
            }
            else
            {
                TxtPassword.UseSystemPasswordChar = !ChBox_MostrarContraseña.Checked && esPassword;
            }
        }

        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            var service = new UsuarioService();
            var user = service.Login(TxtNameUser.Text, TxtPassword.Text);

            if (user != null)
            {
                var empleadoService = new EmpleadoService();
                var empleado = empleadoService.GetEmpleadoById(user.IdEmpleado);
                SessionManager.Instance.SetUsuario(user);
                SessionManager.Instance.SetEmpleado(empleado);

                this.Hide();
                FormWelcome welcome = new FormWelcome();
                welcome.ShowDialog();
                welcome.Hide();

                try
                {
                    MainScreen mainScreen = new MainScreen();
                    mainScreen.Show();
                }
                catch
                {
                    MessageBox.Show(LanguageManager.Traducir("Login_MensajeUsuarioSinRol"));
                }
            }
            else
            {
                MessageBox.Show(LanguageManager.Traducir("Login_MensajeErrorCredenciales"));
            }
        }

        private void LiL_RecuperarPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string username = TxtNameUser.Text.Trim();

            if (string.IsNullOrEmpty(username) || username == "Usuario")
            {
                MessageBox.Show(LanguageManager.Traducir("Login_MensajeUsuarioRequerido"));
                return;
            }

            var usuarioService = new UsuarioService();
            var user = usuarioService.RecuperarClave(username);

            if (user == null)
            {
                MessageBox.Show(LanguageManager.Traducir("Login_MensajeUsuarioNoEncontrado"));
                return;
            }

            if (string.IsNullOrEmpty(user.EmailRecuperacion))
            {
                MessageBox.Show(LanguageManager.Traducir("Login_MensajeSinEmail"));
                return;
            }

            var empleadoService = new EmpleadoService();
            var empleado = empleadoService.GetEmpleadoById(user.IdEmpleado);
            var token = UsuarioService.GenerateToken();
            var expiry = DateTime.Now.AddMinutes(30);
            usuarioService.SaveRecoveryToken(username, token, expiry);

            try
            {
                var emailService = new EmailService();
                emailService.EnviarRecuperacionClave(empleado, token, username);
                MessageBox.Show($"{LanguageManager.Traducir("Login_MensajeMailEnviado")} {user.EmailRecuperacion}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{LanguageManager.Traducir("Login_MensajeErrorEnvioMail")} {ex.Message}");
            }
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e) => Application.Exit();
        private void Btn_Minimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}