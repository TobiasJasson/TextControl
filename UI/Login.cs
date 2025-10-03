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
using UI.Admin;
using UI.EmpleadosForms;
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
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void LiL_RecuperarPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string username = TxtNameUser.Text.Trim();

            if (string.IsNullOrEmpty(username) || username == LanguageManager.Translate("Login_Usuario"))
            {
                MessageBox.Show(LanguageManager.Translate("Login_MensajeUsuarioRequerido"));
                return;
            }

            var usuarioService = new UsuarioService();
            var user = usuarioService.RecuperarClave(username);

            if (user == null)
            {
                MessageBox.Show(LanguageManager.Translate("Login_MensajeUsuarioNoEncontrado"));
                return;
            }

            if (string.IsNullOrEmpty(user.EmailRecuperacion))
            {
                MessageBox.Show(LanguageManager.Translate("Login_MensajeSinEmail"));
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

                MessageBox.Show($"{LanguageManager.Translate("Login_MensajeMailEnviado")} {user.EmailRecuperacion}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{LanguageManager.Translate("Login_MensajeErrorEnvioMail")} {ex.Message}");
            }
        }

        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            var service = new UsuarioService();
            var user = service.Login(TxtNameUser.Text, TxtPassword.Text);

            if (user != null)
            {
                // abrir pantalla principal
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
                }catch
                {
                    MessageBox.Show(LanguageManager.Translate("Login_MensajeUsuarioSinRol"));
                }

                //if (empleado.IdRol == 1)
                //{
                //    MainScreen admin = new MainScreen("admin");
                //    admin.Show();
                //} else if (empleado.IdRol == 2)
                //{
                //    MainScreen empleadoForm = new MainScreen("empleado");
                //    empleadoForm.Show();
                //}
                //else
                //{

                //    MessageBox.Show(LanguageManager.Translate("Login_MensajeUsuarioSinRol"));
                //}

            }
            else
            {

                MessageBox.Show(LanguageManager.Translate("Login_MensajeErrorCredenciales"));
            }
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtNameUser_TextChanged(object sender, EventArgs e)
        {

        }
        private void TxtNameUser_Enter(object sender, EventArgs e)
        {
            if (TxtNameUser.Text == "Usuario")
            {
                TxtNameUser.Text = "";
                TxtNameUser.ForeColor = Color.Black;
            }
        }

        private void TxtNameUser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNameUser.Text))
            {
                TxtNameUser.Text = "Usuario";
                TxtNameUser.ForeColor = Color.Silver;
            }
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "Contraseña")
            {
                TxtPassword.Text = "";
                TxtPassword.ForeColor = Color.Black;
                TxtPassword.UseSystemPasswordChar = true;
            }
        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtPassword.Text))
            {
                TxtPassword.Text = "Contraseña";
                TxtPassword.ForeColor = Color.Silver;
                TxtPassword.UseSystemPasswordChar = false;
            }
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            LanguageManager.LoadLastLanguage();
            BtnCambiarIdioma.Text = LanguageManager.Translate("Login_BotonIdioma");
            lblTitulo.Text = LanguageManager.Translate("Login_Titulo");
            TxtNameUser.Text = LanguageManager.Translate("Login_Usuario");
            TxtPassword.Text = LanguageManager.Translate("Login_Contraseña");
            ChBox_MostrarContraseña.Text = LanguageManager.Translate("Login_MostrarContraseña");
            Btn_Ingresar.Text = LanguageManager.Translate("Login_BotonIngresar");
            LiL_RecuperarPass.Text = LanguageManager.Translate("Login_OlvidoClave");
            //ReleaseCapture();   
            //SendMessage(this.Handle, 0x112, 0xf012, 0);
            //TxtPassword.Text = "Contraseña";
            //TxtPassword.ForeColor = Color.Silver;
            //TxtPassword.UseSystemPasswordChar = false;
        }


        private void ChBox_MostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBox_MostrarContraseña.Checked)
            {
                // Mostrar la contraseña
                TxtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Ocultar la contraseña con "*"
                TxtPassword.UseSystemPasswordChar = true;
            }
        }

        private void BtnCambiarIdioma_Click(object sender, EventArgs e)
        {
            string nuevoIdioma = LanguageManager.CurrentLanguage == "es-AR" ? "en-EEUU" : "es-AR";
            LanguageManager.LoadLanguage(nuevoIdioma);
            ApplyTranslations();
        }
        private void ApplyTranslations()
        {
            lblTitulo.Text = LanguageManager.Translate("Login_Titulo");
            TxtNameUser.Text = LanguageManager.Translate("Login_Usuario");
            TxtPassword.Text = LanguageManager.Translate("Login_Contraseña");
            ChBox_MostrarContraseña.Text = LanguageManager.Translate("Login_MostrarContraseña");
            Btn_Ingresar.Text = LanguageManager.Translate("Login_BotonIngresar");
            LiL_RecuperarPass.Text = LanguageManager.Translate("Login_OlvidoClave");
            BtnCambiarIdioma.Text = LanguageManager.Translate("Login_BotonIdioma");
        }
    }

}
