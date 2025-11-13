using BLL.Servicios;
using Domain_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Services.MultiIdioma;
using UI.LocalWidget;

namespace UI.FormsComun
{
    public partial class FormStock : Form
    {
        private readonly InsumoService _service = new InsumoService();
        private List<Insumo> _insumos;
        private Timer _busquedaTimer;

        public FormStock()
        {
            InitializeComponent();
            LanguageManager.IdiomaCambiado += OnIdiomaCambiado;
        }

        private void OnIdiomaCambiado()
        {
            TraducirUI();
        }

        private void TraducirUI()
        {
            this.Text = LanguageManager.Traducir("SideMenu_Stock");

            if (DataGrid_Stock.Columns.Count > 0)
            {
                DataGrid_Stock.Columns["TipoInsumo"].HeaderText = LanguageManager.Traducir("Stock_Tipo");
                DataGrid_Stock.Columns["Nombre"].HeaderText = LanguageManager.Traducir("Stock_Nombre");
                DataGrid_Stock.Columns["Color"].HeaderText = LanguageManager.Traducir("Stock_Color");
                DataGrid_Stock.Columns["StockActual"].HeaderText = LanguageManager.Traducir("Stock_StockActual");
                DataGrid_Stock.Columns["StockMinimo"].HeaderText = LanguageManager.Traducir("Stock_StockMinimo");
                DataGrid_Stock.Columns["UltimaSalida"].HeaderText = LanguageManager.Traducir("Stock_UltimaSalida");
                DataGrid_Stock.Columns["PrecioUnitario"].HeaderText = LanguageManager.Traducir("Stock_PrecioUnitario");
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
            panelSuperior.Controls.Add(Btn_Editar);
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
            if (DataGrid_Stock.SelectedRows.Count == 0)
                return;

            var fila = DataGrid_Stock.SelectedRows[0];
            string nombre = fila.Cells["Nombre"].Value.ToString();
            var insumo = _insumos.FirstOrDefault(i => i.Nombre == nombre);
            if (insumo == null) return;

            //using (var form = new FormEditarInsumo(insumo))
            //{
            //    if (form.ShowDialog() == DialogResult.OK)
            //    {
            //        _service.Actualizar(form.InsumoEditado);
            //        CargarStock();
            //    }
            //}
        }

        private void Btn_Exportar_Click(object sender, EventArgs e)
        {
            var exporter = new ExcelExporter();
            exporter.ExportarDataGridConColores(DataGrid_Stock);
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

            DataGrid_Stock.Columns.Add("TipoInsumo", "Tipo");
            DataGrid_Stock.Columns.Add("Nombre", "Nombre");
            DataGrid_Stock.Columns.Add("Color", "Color");
            DataGrid_Stock.Columns.Add("StockActual", "Stock Actual");
            DataGrid_Stock.Columns.Add("StockMinimo", "Stock Mínimo");
            DataGrid_Stock.Columns.Add("UltimaSalida", "Última Salida");
            DataGrid_Stock.Columns.Add("PrecioUnitario", "Precio Unitario");

            var formatoPesos = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            formatoPesos = new CultureInfo("es-AR");
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
                    ins.TipoInsumo,
                    ins.Nombre,
                    ins.Color,
                    ins.StockActual,
                    ins.StockMinimo,
                    ins.UltimaSalida?.ToShortDateString() ?? "—",
                    ins.PrecioUnitario
                );

                var fila = DataGrid_Stock.Rows[rowIndex];

                int diferencia = ins.StockActual - ins.StockMinimo;
                if (diferencia <= 20)
                    fila.DefaultCellStyle.BackColor = Color.LightCoral;
                else if (diferencia <= 50)
                    fila.DefaultCellStyle.BackColor = Color.Khaki;
                else
                    fila.DefaultCellStyle.BackColor = Color.White;
            }

            DataGrid_Stock.ClearSelection();
        }
    }
}