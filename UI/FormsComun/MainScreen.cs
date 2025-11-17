using BLL;
using Services.Conifguraciones;
using Services.MultiIdioma;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.FormsComun;
using UI.FormsComun.Admin;
using UI.FormsComun.OrdenesPedidos;
using UI.LocalWidget;

namespace UI
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            ThemeManager.LoadTheme();
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        bool menuExpandido = true;
        private void BtnCambiarIdioma_Click(object sender, EventArgs e)
        {
            string nuevoIdioma = LanguageManager.IdiomaActual == "es-AR" ? "en-EEUU" : "es-AR";
            LanguageManager.CargarIdioma(nuevoIdioma);
            ApplyTranslations();
        }
        private void ApplyTranslations()
        {
            lblTitle.Text = LanguageManager.Traducir("Dashboard_Titulo");
            BtnCambiarIdioma.Text = LanguageManager.Traducir("Login_BotonIdioma");
            Btn_Usuarios.Text = LanguageManager.Traducir("SideMenu_Usuario");
            BtnReporte.Text = LanguageManager.Traducir("SideMenu_Reporte");
            BtnStock.Text = LanguageManager.Traducir("SideMenu_Stock");
            BtnConfig.Text = LanguageManager.Traducir("SideMenu_Configuraciones");
            Btn_LogOut.Text = LanguageManager.Traducir("SideMenu_Salir");
            Btn_Venta.Text = LanguageManager.Traducir("SideMenu_Venta");
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMaximize_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            Panel_Title.Dock = DockStyle.Top;
            panel_Menu.Dock = DockStyle.Left;
            panelContenido.Dock = DockStyle.Fill;

            panel_Menu.Width = 0;
            //Btn_Usuarios.Visible = false;
            //BtnReporte.Visible = false;
            //BtnStock.Visible = false;
            //BtnConfig.Visible = false;
            //Btn_LogOut.Visible = false;
            //BtnCambiarIdioma.Visible = false;
            menuExpandido = false;

            Btn_Cerrar.Location = new Point(Panel_Title.Width - Btn_Cerrar.Width - 5, 5);
            BtnMaximize.Location = new Point(Btn_Cerrar.Left - BtnMaximize.Width - 5, 5);
            Btn_Minimize.Location = new Point(BtnMaximize.Left - Btn_Minimize.Width - 5, 5);

            Btn_Cerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Btn_Minimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            int rol = SessionManager.Instance.EmpleadoActual.IdRol;

            if (rol == 1)//Admin
            {
                Btn_Usuarios.Visible = true;
                BtnReporte.Visible = true;
            }
            else if (rol == 2)//Empleado
            {
                Btn_Usuarios.Visible = false;
                BtnReporte.Visible = false;
            }

            LanguageManager.CargarUltimoIdioma();
            lblTitle.Text = LanguageManager.Traducir("Dashboard_Titulo");
            BtnCambiarIdioma.Text = LanguageManager.Traducir("Login_BotonIdioma");
            Btn_Usuarios.Text = LanguageManager.Traducir("SideMenu_Usuario");
            BtnReporte.Text = LanguageManager.Traducir("SideMenu_Reporte");
            BtnStock.Text = LanguageManager.Traducir("SideMenu_Stock");
            Btn_Venta.Text = LanguageManager.Traducir("SideMenu_Venta");
            BtnConfig.Text = LanguageManager.Traducir("SideMenu_Configuraciones");
            Btn_LogOut.Text = LanguageManager.Traducir("SideMenu_Salir");
        }

        private void Panel_Title_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel_Menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btn_MenuDesplegable_Click(object sender, EventArgs e)
        {
            if (!menuExpandido)
            {
                panel_Menu.Width = 0;
                Btn_MenuDesplegable.BringToFront();
            }
            else
            {
                panel_Menu.Width = 282;
                Btn_MenuDesplegable.BringToFront();
            }

            menuExpandido = !menuExpandido;
        }

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void BtnConfig_Click(object sender, EventArgs e)
        {
            lblTitle.Text = LanguageManager.Traducir("SideMenu_Configuraciones");

            panelContenido.Controls.Clear();

            bool oscuro = ThemeManager.ModoOscuro;
            Label lblCargando = new Label()
            {
                Text = "Cargando ...",
                ForeColor = Color.Gray,
                BackColor = (oscuro == true) ?Color.Black :Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelContenido.Controls.Add(lblCargando);
            panelContenido.Refresh();

            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(500);
            });

            FormConfig formConfig = new FormConfig();
            formConfig.TopLevel = false;
            formConfig.FormBorderStyle = FormBorderStyle.None;
            formConfig.Dock = DockStyle.Fill;

            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(formConfig);
            ThemeManager.ApplyTheme(formConfig, ThemeManager.ModoOscuro);
            formConfig.Show();
        }

        private async void BtnStock_Click(object sender, EventArgs e)
        {
            lblTitle.Text = LanguageManager.Traducir("SideMenu_Stock");

            panelContenido.Controls.Clear();

            bool oscuro = ThemeManager.ModoOscuro;
            Label lblCargando = new Label()
            {
                Text = "Cargando ...",
                ForeColor = Color.Gray,
                BackColor = (oscuro == true) ? Color.Black : Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelContenido.Controls.Add(lblCargando);
            panelContenido.Refresh();

            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(500);
            });

            FormStock formStock = new FormStock();
            formStock.TopLevel = false;
            formStock.FormBorderStyle = FormBorderStyle.None;
            formStock.Dock = DockStyle.Fill;

            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(formStock);
            ThemeManager.ApplyTheme(formStock, ThemeManager.ModoOscuro);
            formStock.Show();
        }

        private async void BtnReporte_Click(object sender, EventArgs e)
        {
            lblTitle.Text = LanguageManager.Traducir("SideMenu_Reporte");
            panelContenido.Controls.Clear();

            bool oscuro = ThemeManager.ModoOscuro;
            Label lblCargando = new Label()
            {
                Text = LanguageManager.Traducir("Cargando"),
                ForeColor = Color.Gray,
                BackColor = oscuro ? Color.Black : Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelContenido.Controls.Add(lblCargando);
            panelContenido.Refresh();

            await Task.Run(() => { System.Threading.Thread.Sleep(500); });

            FormOrdenesPedidos form = new FormOrdenesPedidos();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(form);
            ThemeManager.ApplyTheme(form, ThemeManager.ModoOscuro);
            form.Show();
        }

        private async void Btn_Usuarios_Click(object sender, EventArgs e)
        {
            lblTitle.Text = LanguageManager.Traducir("SideMenu_Usuario");
            panelContenido.Controls.Clear();

            bool oscuro = ThemeManager.ModoOscuro;
            Label lblCargando = new Label()
            {
                Text = "Cargando ...",
                ForeColor = Color.Gray,
                BackColor = (oscuro == true) ? Color.Black : Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelContenido.Controls.Add(lblCargando);
            panelContenido.Refresh();

            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(500);
            });

            FormControlEmpleado formEmpleado = new FormControlEmpleado();
            formEmpleado.TopLevel = false;
            formEmpleado.FormBorderStyle = FormBorderStyle.None;
            formEmpleado.Dock = DockStyle.Fill;

            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(formEmpleado);
            ThemeManager.ApplyTheme(formEmpleado, ThemeManager.ModoOscuro);
            formEmpleado.Show();
        }

        private void Btn_Venta_Click(object sender, EventArgs e)
        {
            lblTitle.Text = LanguageManager.Traducir("SideMenu_Venta");
        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            var result = CustomMessageBox.Show(
                LanguageManager.Traducir("SideMenu_BoxLogOut"),
                LanguageManager.Traducir("SideMenu_Usuario")
            );

            switch (result)
            {
                case DialogResult.Yes:
                    SessionManager.Instance.SetUsuario(null);
                    SessionManager.Instance.SetEmpleado(null);

                    Login login = new Login();
                    login.Show();

                    this.Close();
                    break;

                case DialogResult.No:
                    Application.Exit();
                    break;

                case DialogResult.Cancel:
                    break;
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
