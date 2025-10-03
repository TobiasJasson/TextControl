using BLL;
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

namespace UI
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }
        bool menuExpandido = true;
        private void BtnCambiarIdioma_Click(object sender, EventArgs e)
        {
            string nuevoIdioma = LanguageManager.CurrentLanguage == "es-AR" ? "en-EEUU" : "es-AR";
            LanguageManager.LoadLanguage(nuevoIdioma);
            ApplyTranslations();
        }
        private void ApplyTranslations()
        {
            lblTitle.Text = LanguageManager.Translate("Dashboard_Titulo");
            BtnCambiarIdioma.Text = LanguageManager.Translate("Login_BotonIdioma");
            Btn_Usuarios.Text = LanguageManager.Translate("SideMenu_Usuario");
            BtnReporte.Text = LanguageManager.Translate("SideMenu_Reporte");
            BtnStock.Text = LanguageManager.Translate("SideMenu_Stock");
            BtnConfig.Text = LanguageManager.Translate("SideMenu_Configuraciones");
            Btn_LogOut.Text = LanguageManager.Translate("SideMenu_Salir");
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
                BtnReporte.Visible = true;
            }

            LanguageManager.LoadLastLanguage();
            lblTitle.Text = LanguageManager.Translate("Dashboard_Titulo");
            BtnCambiarIdioma.Text = LanguageManager.Translate("Login_BotonIdioma");
            Btn_Usuarios.Text = LanguageManager.Translate("SideMenu_Usuario");
            BtnReporte.Text = LanguageManager.Translate("SideMenu_Reporte");
            BtnStock.Text = LanguageManager.Translate("SideMenu_Stock");
            BtnConfig.Text = LanguageManager.Translate("SideMenu_Configuraciones");
            Btn_LogOut.Text = LanguageManager.Translate("SideMenu_Salir");
        }

        private void Panel_Title_Paint(object sender, PaintEventArgs e)
        {

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

    }
}
