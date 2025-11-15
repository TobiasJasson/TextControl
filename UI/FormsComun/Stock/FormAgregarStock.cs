using BLL.Servicios;
using Domain_Model;
using Services.Conifguraciones;
using Services.MultiIdioma;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.LocalWidget;

namespace UI.FormsComun.Stock
    {
        public partial class FormAgregarStock : BaseForm
        {

            private TipoInsumoService _tipoService = new TipoInsumoService();
            private InsumoService _insumoService = new InsumoService();
            public FormAgregarStock()
            {
                ThemeManager.LoadTheme();
                InitializeComponent();
                AplicarTema();
            }

            protected override void TraducirUI()
            {
                this.Text = LanguageManager.Traducir("Title_AgregarStock");

                Lbl_titleTipoStock.Text = LanguageManager.Traducir("Lbl_titleTipoStock");
                Lbl_NombreInsumo.Text = LanguageManager.Traducir("Lbl_NombreInsumo");
                Lbl_ColorInsumo.Text = LanguageManager.Traducir("Lbl_ColorInsumo");
                Lbl_StockMinimo.Text = LanguageManager.Traducir("Lbl_StockMinimo");
                Lbl_StockActual.Text = LanguageManager.Traducir("Lbl_StockActual");
                Lbl_CantidadUnidad.Text = LanguageManager.Traducir("Lbl_CantidadUnidad");
                Lbl_PrecioUnitario.Text = LanguageManager.Traducir("Lbl_PrecioUnitario");

                Btn_Agregar.Text = LanguageManager.Traducir("Btn_Aceptar");
                Btn_Cancelar.Text = LanguageManager.Traducir("Btn_Cancel");
            }

        
        private void FormAgregarStock_Load(object sender, EventArgs e)
            {

            TraducirUI();
            AplicarTema();
                CBX_TipoInsumo.TextUpdate += CBX_TipoInsumo_TextUpdate;
                CargarColores();
                CargarTiposInsumo();
                CBX_TipoInsumo.DropDownStyle = ComboBoxStyle.DropDown;

                CBX_TipoInsumo.MouseClick += (s, ev) =>
                {
                    if (!CBX_TipoInsumo.DroppedDown)
                        CBX_TipoInsumo.DroppedDown = true;
                };
            }

        private void AplicarTema()
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

        private void CargarTiposInsumo()
        {
            var tipos = _tipoService.ObtenerTodos();

            // Insertamos un item vacío al inicio
            tipos.Insert(0, new TipoInsumo
            {
                ID_TipoInsumo = 0,
                Descripcion = ""
            });

            CBX_TipoInsumo.DataSource = tipos;
            CBX_TipoInsumo.DisplayMember = "Descripcion";
            CBX_TipoInsumo.ValueMember = "ID_TipoInsumo";

            CBX_TipoInsumo.SelectedIndex = 0;
            CBX_TipoInsumo.DropDownStyle = ComboBoxStyle.DropDown;
            CBX_TipoInsumo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CBX_TipoInsumo.AutoCompleteSource = AutoCompleteSource.ListItems;

            CBX_TipoInsumo.MouseClick += (s, e) =>
            {
                CBX_TipoInsumo.DroppedDown = true;
            };
        }
        private void CargarColores()
        {
            var colores = new ColorService().ObtenerTodosLosColores();

            colores.Insert(0, new ColorModel
            {
                ID_Color = 0,
                Descripcion = ""
            });

            CBX_Color.DataSource = colores;
            CBX_Color.DisplayMember = "Descripcion";
            CBX_Color.ValueMember = "ID_Color";

            CBX_Color.SelectedIndex = 0;
            CBX_Color.DropDownStyle = ComboBoxStyle.DropDown;
            CBX_Color.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CBX_Color.AutoCompleteSource = AutoCompleteSource.ListItems;

            CBX_Color.MouseClick += (s, e) =>
            {
                if (!CBX_Color.DroppedDown)
                    CBX_Color.DroppedDown = true;
            };
        }

        private void CBX_TipoInsumo_TextUpdate(object sender, EventArgs e)
        {
            string texto = CBX_TipoInsumo.Text.Trim();

            var lista = string.IsNullOrWhiteSpace(texto)
                ? _tipoService.ObtenerTodos()
                : _tipoService.BuscarCoincidencias(texto)
                              .Select(t => new TipoInsumo { Descripcion = t })
                              .ToList();

            lista.Insert(0, new TipoInsumo { ID_TipoInsumo = 0, Descripcion = "" });

            int pos = CBX_TipoInsumo.SelectionStart;

            CBX_TipoInsumo.BeginUpdate();
            CBX_TipoInsumo.DataSource = lista;
            CBX_TipoInsumo.DisplayMember = "Descripcion";
            CBX_TipoInsumo.ValueMember = "ID_TipoInsumo";
            CBX_TipoInsumo.EndUpdate();

            CBX_TipoInsumo.DroppedDown = true;
            CBX_TipoInsumo.SelectionStart = pos;
        }

        private void CBX_TipoInsumo_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (CBX_TipoInsumo.Text.Length < 2)
                    return;

                var lista = _tipoService.BuscarCoincidencias(CBX_TipoInsumo.Text);

                CBX_TipoInsumo.Items.Clear();
                CBX_TipoInsumo.Items.AddRange(lista.ToArray());
                CBX_TipoInsumo.DroppedDown = true;
                CBX_TipoInsumo.SelectionStart = CBX_TipoInsumo.Text.Length;
            }

            private void Txt_NombreInsumo_TextChanged(object sender, EventArgs e)
            {

            }

            private void Txt_StockActual_TextChanged(object sender, EventArgs e)
            {

            }

            private void Txt_StockMinimo_TextChanged(object sender, EventArgs e)
            {

            }

            private void Txt_CantidadUnidad_TextChanged(object sender, EventArgs e)
            {

            }

            private void Txt_PrecioUnitario_TextChanged(object sender, EventArgs e)
            {

            }

            private void Btn_Agregar_Click(object sender, EventArgs e)
            {
            try
            {
                if (string.IsNullOrWhiteSpace(CBX_TipoInsumo.Text))
                    throw new Exception("Debe ingresar un tipo de insumo.");

                if (string.IsNullOrWhiteSpace(Txt_NombreInsumo.Text))
                    throw new Exception("Debe ingresar un nombre.");

                if (!int.TryParse(Txt_StockActual.Text, out int stockActual))
                    throw new Exception("Stock actual inválido.");

                if (!int.TryParse(Txt_StockMinimo.Text, out int stockMinimo))
                    throw new Exception("Stock mínimo inválido.");

                if (!int.TryParse(Txt_CantidadUnidad.Text, out int cantidadUnidad))
                    throw new Exception("Cantidad por unidad inválida.");

                if (!decimal.TryParse(Txt_PrecioUnitario.Text.Replace(",", "."), NumberStyles.Any,
                    CultureInfo.InvariantCulture, out decimal precioUnitario))
                    throw new Exception("Precio inválido.");

                int idTipo = _tipoService.ObtenerOCrear(CBX_TipoInsumo.Text.Trim());

                var model = new InsumoInsert
                {
                    ID_TipoInsumo = idTipo,
                    Nombre = Txt_NombreInsumo.Text.Trim(),
                    ID_Color = CBX_Color.SelectedValue != null
                        ? Convert.ToInt32(CBX_Color.SelectedValue)
                        : (int?)null,
                    CantidadPorUnidad = cantidadUnidad,
                    StockActual = stockActual,
                    StockMinimo = stockMinimo,
                    PrecioUnitario = precioUnitario
                };

                int idNuevo = _insumoService.CrearInsumo(model);

                MessageBox.Show(
                        $"{LanguageManager.Traducir("Lbl_titleTipoStock")} {CBX_TipoInsumo.Text} {LanguageManager.Traducir("Mensaje_Exito").ToLower()}",
                        LanguageManager.Traducir("Mensaje_Exito"));

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

            private void Btn_Cancelar_Click(object sender, EventArgs e)
            {

                MainScreen mainScreen = Navigator.GetMain(this);
                if (mainScreen == null) { Close(); return; }

                FormStock form = new FormStock()
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

            mainScreen.lblTitle.Text = LanguageManager.Traducir("SideMenu_Stock");

            mainScreen.panelContenido.Controls.Clear();
            mainScreen.panelContenido.Controls.Add(form);

                ThemeManager.ApplyTheme(form, ThemeManager.ModoOscuro);

                form.Show();
            }

            private void CBX_Color_SelectedIndexChanged(object sender, EventArgs e)
            {
            }

        private void Lbl_titleTipoStock_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_NombreInsumo_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_ColorInsumo_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_StockMinimo_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_StockActual_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_CantidadUnidad_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_PrecioUnitario_Click(object sender, EventArgs e)
        {

        }
    }
    }
