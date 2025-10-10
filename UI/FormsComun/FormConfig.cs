using Services.Conifguraciones;
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
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            bool oscuro = ThemeManager.ModoOscuro;
            Switch_modoOscuro.Checked = oscuro;
            ThemeManager.ApplyTheme(this, oscuro);
        }

        private void Switch_modoOscuro_CheckedChanged(object sender, EventArgs e)
        {
            bool oscuro = Switch_modoOscuro.Checked;
            ThemeManager.SaveTheme(oscuro);
            ThemeManager.ApplyTheme(this, oscuro);
        }

        private void TxtNuevaClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtConfirmarClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Txt_NuevoMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_NuevoMail_Click(object sender, EventArgs e)
        {

        }
    }
}
