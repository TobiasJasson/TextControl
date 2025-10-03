using BLL;
using DAL;
using DomainModel;
using Services.MultiIdioma;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            circularProgressBar1.Value += 1;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString(); 
            if (circularProgressBar1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Close();
            }
        }

        private void FormWelcome_Load(object sender, EventArgs e)
        {
            LanguageManager.LoadLastLanguage();

            var empleadoActual = SessionManager.Instance.EmpleadoActual;
            lbl_Username.Text = empleadoActual.Nombre + " " + empleadoActual.Apellido;
            this.Opacity = 0.0;
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            label2.Text = LanguageManager.Translate("Welcome_Bienvenido");
            timer1.Start();
        }

        private void lbl_Username_Click(object sender, EventArgs e)
        {

        }


        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
