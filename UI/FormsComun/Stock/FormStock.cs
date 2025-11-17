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
using UI.FormsComun.Stock;
using UI.LocalWidget;

namespace UI.FormsComun
{
    public partial class FormStock : BaseForm
    {
        private readonly InsumoService _service = new InsumoService();
        private List<Insumo> _insumos;
        private Timer _busquedaTimer;
        private bool _modoEdicion = false;
        private int _filaEditando = -1;

        public FormStock()
        {
            ThemeManager.LoadTheme();
            InitializeComponent();
        }
        protected override void TraducirUI()
        {
            this.Text = LanguageManager.Traducir("SideMenu_Stock");

            if (DataGrid_Stock.Columns.Count > 0)
            {
                DataGrid_Stock.Columns["TipoInsumo"].HeaderText = LanguageManager.Traducir("Stock_Tipo");
                DataGrid_Stock.Columns["Nombre"].HeaderText = LanguageManager.Traducir("Stock_Nombre");
                if (DataGrid_Stock.Columns.Contains("Color"))
                    DataGrid_Stock.Columns["Color"].HeaderText = LanguageManager.Traducir("Stock_Color");
                DataGrid_Stock.Columns["StockActual"].HeaderText = LanguageManager.Traducir("Stock_StockActual");
                DataGrid_Stock.Columns["StockMinimo"].HeaderText = LanguageManager.Traducir("Stock_StockMinimo");
                DataGrid_Stock.Columns["UltimaSalida"].HeaderText = LanguageManager.Traducir("Stock_UltimaSalida");
                DataGrid_Stock.Columns["PrecioUnitario"].HeaderText = LanguageManager.Traducir("Stock_PrecioUnitario");
                Btn_Agregar.Text = LanguageManager.Traducir("Boton_Agregar");
                Btn_Editar.Text = _modoEdicion
                    ? LanguageManager.Traducir("Boton_Actualizar")
                    : LanguageManager.Traducir("Boton_Editar");
                Btn_Eliminar.Text = LanguageManager.Traducir("Boton_Eliminar");
                Btn_Exportar.Text = LanguageManager.Traducir("Boton_Exportar");
            }
        }

        private void FormStock_Load(object sender, EventArgs e)
        {
            ConfigurarLayoutResponsive();
            ConfigurarColumnas();
            CargarStock();
            TraducirUI();
        }
        private void ConfigurarLayoutResponsive()
        {
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2
            };

            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            var panelSuperior = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(10)
            };

            panelSuperior.Controls.Add(Txt_Buscador);
            panelSuperior.Controls.Add(Btn_Agregar);
            panelSuperior.Controls.Add(Btn_Editar);
            panelSuperior.Controls.Add(Btn_Eliminar);
            panelSuperior.Controls.Add(Btn_Exportar);

            DataGrid_Stock.Dock = DockStyle.Fill;
            DataGrid_Stock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGrid_Stock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            layout.Controls.Add(panelSuperior, 0, 0);
            layout.Controls.Add(DataGrid_Stock, 0, 1);

            this.Controls.Clear();
            this.Controls.Add(layout);
        }

        private void AjustarTamanioFuente()
        {
            float factor = this.Width / 800f;
            float nuevoTamaño = 10f * factor;

            DataGrid_Stock.DefaultCellStyle.Font = new Font("Segoe UI", nuevoTamaño);
            DataGrid_Stock.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", nuevoTamaño + 1);
        }

        private void FormStock_Resize(object sender, EventArgs e)
        {
            AjustarTamanioFuente();
        }

        private void Txt_Buscador_TextChanged(object sender, EventArgs e)
        {
            if (_busquedaTimer == null)
            {
                _busquedaTimer = new Timer();
                _busquedaTimer.Interval = 300;
                _busquedaTimer.Tick += (s, ev) =>
                {
                    _busquedaTimer.Stop();
                    string filtro = Txt_Buscador.Text.Trim();
                    var filtrados = _service.Buscar(filtro);
                    MostrarDatos(filtrados);
                };
            }

            _busquedaTimer.Stop();
            _busquedaTimer.Start();
        }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            if (!_modoEdicion)
            {
                if (DataGrid_Stock.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        LanguageManager.Traducir("Msg_SeleccionEditar"),
                        LanguageManager.Traducir("Mensaje_Atencion"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                _filaEditando = DataGrid_Stock.SelectedRows[0].Index;
                DataGrid_Stock.ReadOnly = false;

                foreach (DataGridViewRow row in DataGrid_Stock.Rows)
                {

                    row.ReadOnly = row.Index != _filaEditando;

                    row.Cells["Color"].ReadOnly = false;
                    DataGrid_Stock.Columns["PrecioUnitario"].DefaultCellStyle.Format = null;

                Btn_Editar.Text = LanguageManager.Traducir("Boton_Actualizar");
                _modoEdicion = true;
                }
            }
            else
            {
                var fila = DataGrid_Stock.Rows[_filaEditando];

                int id = Convert.ToInt32(fila.Cells["ID_Insumo"].Value);

                var insumo = _insumos.FirstOrDefault(i => i.ID_Insumo == id);
                if (insumo == null) return;

                insumo.Nombre = fila.Cells["Nombre"].Value?.ToString() ?? "";

                insumo.TipoInsumo = fila.Cells["TipoInsumo"].Value?.ToString() ?? "";

                if (int.TryParse(fila.Cells["Color"].Value?.ToString(), out int idColor))
                    insumo.ID_Color = fila.Cells["Color"].Value != null
                            ? Convert.ToInt32(fila.Cells["Color"].Value)
                            : (int?)null;

                insumo.StockActual =
                    int.TryParse(fila.Cells["StockActual"].Value?.ToString(), out int sa) ? sa : 0;

                insumo.StockMinimo =
                    int.TryParse(fila.Cells["StockMinimo"].Value?.ToString(), out int sm) ? sm : 0;

                string precioTexto = fila.Cells["PrecioUnitario"].Value?.ToString() ?? "0";
                precioTexto = precioTexto
                    .Replace("$", "")
                    .Replace(" ", "")
                    .Replace(".", "")
                    .Replace(",", ".");

                insumo.PrecioUnitario =
                    double.TryParse(precioTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out double pu)
                        ? pu
                        : 0;

                _service.Actualizar(insumo);

                MessageBox.Show(
                    LanguageManager.Traducir("Msg_EditadoCorrectamente"),
                    LanguageManager.Traducir("Mensaje_Exito"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                _modoEdicion = false;
                _filaEditando = -1;
                DataGrid_Stock.ReadOnly = true;

                DataGrid_Stock.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
                DataGrid_Stock.Columns["PrecioUnitario"].DefaultCellStyle.FormatProvider = new CultureInfo("es-AR");

                Btn_Editar.Text = LanguageManager.Traducir("Boton_Editar");
                CargarStock();
            }
        }

        private void Btn_Exportar_Click(object sender, EventArgs e)
        {
            var exporter = new ExcelExporter();
            exporter.ExportarStock(DataGrid_Stock);
        }

        private void DataGrid_Stock_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void CargarStock()
        {
            _insumos = _service.ObtenerStock();
            MostrarDatos(_insumos);
        }
        private void ConfigurarColumnas()
        {
            DataGrid_Stock.AutoGenerateColumns = false;
            DataGrid_Stock.Columns.Clear();

            var colId = new DataGridViewTextBoxColumn();
            colId.Name = "ID_Insumo";
            colId.HeaderText = "ID";
            colId.Visible = false;
            var colColor = new DataGridViewComboBoxColumn();
            colColor.Name = "Color";
            colColor.HeaderText = "Color";
            colColor.DisplayMember = "Descripcion";
            colColor.ValueMember = "ID_Color";
            colColor.DataSource = new ColorService().ObtenerTodosLosColores();
            colColor.FlatStyle = FlatStyle.Flat;

            DataGrid_Stock.Columns.Add(colId);

            DataGrid_Stock.Columns.Add("TipoInsumo", "Tipo");
            DataGrid_Stock.Columns.Add("Nombre", "Nombre");
            DataGrid_Stock.Columns.Add(colColor);
            DataGrid_Stock.Columns.Add("StockActual", "Stock Actual");
            DataGrid_Stock.Columns.Add("StockMinimo", "Stock Mínimo");
            DataGrid_Stock.Columns.Add("UltimaSalida", "Última Salida");
            DataGrid_Stock.Columns.Add("PrecioUnitario", "Precio Unitario");

            var formatoPesos = new CultureInfo("es-AR");
            DataGrid_Stock.Columns["PrecioUnitario"].DefaultCellStyle.FormatProvider = formatoPesos;
            DataGrid_Stock.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";

            DataGrid_Stock.AllowUserToAddRows = false;
            DataGrid_Stock.ReadOnly = true;
            DataGrid_Stock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGrid_Stock.MultiSelect = false;
        }

        private void MostrarDatos(List<Insumo> lista)
        {
            DataGrid_Stock.Rows.Clear();

            foreach (var ins in lista)
            {
                int rowIndex = DataGrid_Stock.Rows.Add(
                    ins.ID_Insumo,
                    ins.TipoInsumo,
                    ins.Nombre,
                    ins.ID_Color,
                    ins.StockActual,
                    ins.StockMinimo,
                    ins.UltimaSalida?.ToShortDateString() ?? "—",
                    ins.PrecioUnitario
                );

                var fila = DataGrid_Stock.Rows[rowIndex];

                int diferencia = ins.StockActual - ins.StockMinimo;
                if (diferencia <= 20)
                    fila.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                else if (diferencia <= 50)
                    fila.DefaultCellStyle.BackColor = System.Drawing.Color.Khaki;
                else
                    fila.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            }

            DataGrid_Stock.ClearSelection();
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (DataGrid_Stock.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    LanguageManager.Traducir("Msg_SeleccionEliminar"),
                    LanguageManager.Traducir("Mensaje_Atencion"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var fila = DataGrid_Stock.SelectedRows[0];
            int id = Convert.ToInt32(fila.Cells["ID_Insumo"].Value);
            var confirm = MessageBox.Show(
                LanguageManager.Traducir("Msg_ConfirmarEliminar"),
                LanguageManager.Traducir("Mensaje_Confirmacion"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (confirm == DialogResult.Yes)
            {
                _service.Eliminar(id);
                MessageBox.Show(
                    LanguageManager.Traducir("Msg_EliminadoCorrectamente"),
                    LanguageManager.Traducir("Mensaje_Exito"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                CargarStock();
            }
        }
        private async void  Btn_Agregar_Click(object sender, EventArgs e)
        {
            MainScreen mainScreen = Navigator.GetMain(this);

            if (mainScreen == null)
            {
                MessageBox.Show("No se encontró el contenedor principal.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mainScreen.lblTitle.Text = LanguageManager.Traducir("Title_AgregarStock");

            bool oscuro = ThemeManager.ModoOscuro;

            Label lblCargando = new Label()
            {
                Text = "Cargando...",
                ForeColor = System.Drawing.Color.Gray,
                BackColor = oscuro ? System.Drawing.Color.Black : System.Drawing.Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            mainScreen.panelContenido.Controls.Clear();
            mainScreen.panelContenido.Controls.Add(lblCargando);
            mainScreen.panelContenido.Refresh();

            await Task.Delay(400);

            FormAgregarStock formAgregar = new FormAgregarStock()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            mainScreen.panelContenido.Controls.Clear();
            mainScreen.panelContenido.Controls.Add(formAgregar);

            ThemeManager.ApplyTheme(formAgregar, ThemeManager.ModoOscuro);

            formAgregar.Show();
        }

    }
}