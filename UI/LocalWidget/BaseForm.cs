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

namespace UI.LocalWidget
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            ThemeManager.LoadTheme();
            LanguageManager.IdiomaCambiado += OnIdiomaCambiadoGlobal;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AplicarTemaGlobal();
            TraducirUI();       // cada pantalla implementa su propia traducción
        }

        private void OnIdiomaCambiadoGlobal()
        {
            TraducirUI();
        }

        protected virtual void TraducirUI()
        {
            // lo implementará cada formulario
        }

        protected virtual void AplicarTemaGlobal()
        {
            bool oscuro = ThemeManager.ModoOscuro;

            Color colorTexto = oscuro ? Color.White : Color.Black;
            Color colorControls = oscuro ? Color.FromArgb(45, 45, 48) : Color.White;

            this.BackColor = oscuro ? Color.FromArgb(30, 30, 30) : Color.White;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label)
                {
                    ctrl.ForeColor = colorTexto;
                    ctrl.BackColor = Color.Transparent;
                }
                else if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.ForeColor = colorTexto;
                    ctrl.BackColor = colorControls;
                }
                else if (ctrl is Button btn)
                {
                    btn.ForeColor = colorTexto;
                    btn.BackColor = oscuro
                        ? Color.FromArgb(60, 60, 60)
                        : Color.Gainsboro;
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            LanguageManager.IdiomaCambiado -= OnIdiomaCambiadoGlobal;
            base.OnFormClosed(e);
        }
    }
}