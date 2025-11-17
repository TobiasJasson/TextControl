using BLL.Servicios;
using Domain_Model;
using Services.Conifguraciones;
using Services.DomainModel;
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
using UI.FormsComun.Stock;
using UI.LocalWidget;

namespace UI.FormsComun.OrdenesPedidos
{
    public partial class FormOrdenesPedidos : BaseForm
    {
        private PedidoService _service;
        private List<PedidoDTO> pedidosOriginal;

        private bool _modoEdicion = false;
        private int _filaEditando = -1;
        public FormOrdenesPedidos()
        {
            ThemeManager.LoadTheme();
            InitializeComponent();
            _service = new PedidoService();
        }
        protected override void TraducirUI()
        {
            this.Text = LanguageManager.Traducir("Menu_OrdenesPedido");

            Lbl_FechaDede.Text = LanguageManager.Traducir("FechaDesde");
            Lbl_FechaHasta.Text = LanguageManager.Traducir("FechaHasta");
            Lbl_EstadoPedido.Text = LanguageManager.Traducir("EstadoPedido");

            Btn_LimpiarFiltros.Text = LanguageManager.Traducir("LimpiarFiltros");
            Btn_Exportar.Text = LanguageManager.Traducir("Exportar");
            Btn_Detalle.Text = LanguageManager.Traducir("Detalle");

            ToolTip t = new ToolTip();
            t.SetToolTip(Btn_Exportar, LanguageManager.Traducir("Exportar"));
            t.SetToolTip(Btn_LimpiarFiltros, LanguageManager.Traducir("LimpiarFiltros"));

            if (dataGridView1.Columns.Count > 0)
            {
                TraducirColumna("ID_pedido", "Pedido_ID");
                TraducirColumna("Cliente", "Cliente");
                TraducirColumna("Contacto", "Contacto");
                TraducirColumna("FechaPedido", "FechaPedido");
                TraducirColumna("FechaEntrega", "FechaEntrega");
                TraducirColumna("Empleado", "Empleado");
                TraducirColumna("Estado", "EstadoPedido");
                TraducirColumna("Total", "Total_Precio");
                TraducirColumna("Adelanto", "Pago_Adelanto");
                TraducirColumna("Detalle", "Detalle");
            }
        }

        private void TraducirColumna(string nombreCol, string claveIdioma)
        {
            if (dataGridView1.Columns.Contains(nombreCol))
                dataGridView1.Columns[nombreCol].HeaderText = LanguageManager.Traducir(claveIdioma);
        }
        private void FormOrdenesPedidos_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            CargarEstados();
            CargarPedidos();
            TraducirUI();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void ConfigurarControles()
        {
            Btn_LimpiarFiltros.Enabled = false;
            Dtp_FechaDesde.Format = DateTimePickerFormat.Custom;
            Dtp_FechaDesde.CustomFormat = " ";

            Dtp_FechaHasta.Format = DateTimePickerFormat.Custom;
            Dtp_FechaHasta.CustomFormat = " ";

            Dtp_FechaDesde.ValueChanged += (s, e) =>
            {
                Dtp_FechaDesde.CustomFormat = "dd/MM/yyyy";
                Filtrar();
            };

            Dtp_FechaHasta.ValueChanged += (s, e) =>
            {
                Dtp_FechaHasta.CustomFormat = "dd/MM/yyyy";
                Filtrar();
            };

            Cbx_EstadoPedido.SelectedIndexChanged += (s, e) => Filtrar();
            if (ThemeManager.ModoOscuro)
                Btn_LimpiarFiltros.ForeColor = Color.Silver;
            else
                Btn_LimpiarFiltros.ForeColor = Color.White;
        }

        private void CargarEstados()
        {
            if (pedidosOriginal == null)
                return;

            var estados = pedidosOriginal
                .Select(x => x.EstadoPedido)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            Cbx_EstadoPedido.Items.Clear();
            Cbx_EstadoPedido.Items.Add(""); // opción vacía

            foreach (var est in estados)
                Cbx_EstadoPedido.Items.Add(est);

            Cbx_EstadoPedido.SelectedIndex = 0;
        }

        private void CargarPedidos()
        {
            pedidosOriginal = _service.ObtenerTodos();

            var pedidosAgrupados = pedidosOriginal
                .GroupBy(p => p.ID_pedido)
                .Select(g => new
                {
                    ID_pedido = g.Key,
                    IDReal = g.First().ID_pedido,
                    Cliente = g.First().Nombre_Cliente,
                    Contacto = g.First().Contacto_Cliente,
                    FechaPedido = g.First().FechaPedido.ToString("dd/MM/yyyy"), // string
                    FechaEntrega = g.First().FechaEntrega_pedido.HasValue
                        ? g.First().FechaEntrega_pedido.Value.ToString("dd/MM/yyyy")
                        : "-", // string si es null
                    Empleado = g.First().Nombre_Empleado + " " + g.First().Apellido_Empleado,
                    Estado = g.First().EstadoPedido,
                    Total = g.First().PrecioTotal_pedido,
                    Adelanto = g.First().pagoAdelanto_pedido
                        ? (double?)g.First().TotalPagosAdelantados
                        : null,
                    Detalle = ConstruirDetalle(g.ToList())
                })
                .OrderBy(x => x.ID_pedido)
                .ToList();


            dataGridView1.DataSource = pedidosAgrupados;
            dataGridView1.Columns["IDReal"].Visible = false;
            dataGridView1.Columns["Total"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["Total"].DefaultCellStyle.FormatProvider =
                new System.Globalization.CultureInfo("es-AR");

            dataGridView1.Columns["FechaPedido"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["FechaEntrega"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dataGridView1.Columns["Adelanto"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["Adelanto"].DefaultCellStyle.FormatProvider =
                new System.Globalization.CultureInfo("es-AR");

            dataGridView1.CellFormatting += (s, ev) =>
            {
                if (dataGridView1.Columns[ev.ColumnIndex].Name == "Adelanto")
                {
                    if (ev.Value == null || ev.Value == DBNull.Value)
                    {
                        ev.Value = "-";
                        ev.FormattingApplied = true;
                    }
                }
            };

            dataGridView1.Columns["Detalle"].Width = 150;

            CargarEstados();
        }
        private void Filtrar()
        {
            if (pedidosOriginal == null)
                return;

            var filtrado = pedidosOriginal;

            if (Dtp_FechaDesde.CustomFormat != " ")
            {
                filtrado = filtrado.Where(p => p.FechaPedido >= Dtp_FechaDesde.Value.Date).ToList();
            }

            if (Dtp_FechaHasta.CustomFormat != " ")
            {
                filtrado = filtrado.Where(p => p.FechaPedido <= Dtp_FechaHasta.Value.Date).ToList();
            }

            if (!string.IsNullOrWhiteSpace(Cbx_EstadoPedido.Text))
            {
                filtrado = filtrado.Where(p => p.EstadoPedido == Cbx_EstadoPedido.Text).ToList();
            }

            var pedidosAgrupados = filtrado
                .GroupBy(p => p.ID_pedido)
                .Select(g => new
                {
                    ID_pedido = g.Key,
                    FechaPedido = g.First().FechaPedido,
                    Cliente = g.First().Nombre_Cliente,
                    Contacto = g.First().Contacto_Cliente,
                    Empleado = g.First().Nombre_Empleado + " " + g.First().Apellido_Empleado,
                    FechaEntrega = g.First().FechaEntrega_pedido,
                    Estado = g.First().EstadoPedido,
                    Total = g.First().PrecioTotal_pedido,
                    Adelanto = g.First().pagoAdelanto_pedido ? (double?)g.First().TotalPagosAdelantados : null,
                    Detalle = ConstruirDetalle(g.ToList())
                })
                .ToList();

            dataGridView1.DataSource = pedidosAgrupados;

            Btn_LimpiarFiltros.Enabled = HayFiltrosActivos();
        }
        private string ConstruirDetalle(List<PedidoDTO> detalles)
        {
            var sb = new StringBuilder();

            foreach (var d in detalles)
            {
                sb.AppendLine($"• {d.Cantidad_Detalle} x Talle {d.Detalles_Talles} - Color {d.Color_Detalle} - ${d.Precio_Detalle}");
            }

            return sb.ToString();
        }

        private void Lbl_FechaDede_Click(object sender, EventArgs e)
        {

        }

        private void Dtp_FechaDesde_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_FechaHasta_Click(object sender, EventArgs e)
        {

        }

        private void Dtp_FechaHasta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_EstadoPedido_Click(object sender, EventArgs e)
        {

        }

        private void Cbx_EstadoPedido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void Btn_Detalle_Click(object sender, EventArgs e)
        {
            MainScreen mainScreen = Navigator.GetMain(this);

            if (mainScreen == null)
            {
                MessageBox.Show(LanguageManager.Traducir("NoSeContenedor") ?? "No se encontró el contenedor principal.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mainScreen.lblTitle.Text = LanguageManager.Traducir("Title_ReporteDetalle");

            bool oscuro = ThemeManager.ModoOscuro;

            Label lblCargando = new Label()
            {
                Text = LanguageManager.Traducir("Cargando") ?? "Cargando...",
                ForeColor = Color.Gray,
                BackColor = oscuro ? Color.Black : Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            mainScreen.panelContenido.Controls.Clear();
            mainScreen.panelContenido.Controls.Add(lblCargando);
            mainScreen.panelContenido.Refresh();

            await Task.Delay(300);

            // Obtener la fila seleccionada de forma robusta
            DataGridViewRow filaSeleccionada = null;

            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            {
                filaSeleccionada = dataGridView1.SelectedRows[0];
            }
            else if (dataGridView1.SelectedCells != null && dataGridView1.SelectedCells.Count > 0)
            {
                filaSeleccionada = dataGridView1.SelectedCells[0].OwningRow;
            }
            else if (dataGridView1.CurrentRow != null)
            {
                filaSeleccionada = dataGridView1.CurrentRow;
            }

            if (filaSeleccionada == null)
            {
                MessageBox.Show(LanguageManager.Traducir("SeleccioneFila") ?? "Seleccione una fila.",
                                LanguageManager.Traducir("Informacion") ?? "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            object valId = null;
            if (dataGridView1.Columns.Contains("IDReal"))
            {
                int idxId = dataGridView1.Columns["IDReal"].Index;
                valId = filaSeleccionada.Cells[idxId].Value;
            }
            else
            {
                // fallback: buscar la primera celda que parezca un entero
                foreach (DataGridViewCell c in filaSeleccionada.Cells)
                {
                    if (c.Value == null) continue;
                    if (int.TryParse(c.Value.ToString(), out _))
                    {
                        valId = c.Value;
                        break;
                    }
                }
            }

            if (valId == null || !int.TryParse(valId.ToString(), out int idPedido))
            {
                MessageBox.Show(LanguageManager.Traducir("IdInvalido") ?? "No se pudo obtener el ID del pedido seleccionado.",
                                LanguageManager.Traducir("Mensaje_Atencion") ?? "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Obtener detalles desde el listado original (ya cargado)
            var detalles = pedidosOriginal
                .Where(p => p.ID_pedido == idPedido)
                .ToList();

            if (detalles == null || detalles.Count == 0)
            {
                MessageBox.Show(LanguageManager.Traducir("NoHayDetalles") ?? "No se encontraron detalles para el pedido seleccionado.",
                                LanguageManager.Traducir("Informacion") ?? "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            var formDetalles = new FormDetallesPedidos(idPedido, detalles)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            mainScreen.panelContenido.Controls.Clear();
            mainScreen.panelContenido.Controls.Add(formDetalles);

            ThemeManager.ApplyTheme(formDetalles, ThemeManager.ModoOscuro);

            formDetalles.Show();
        }

        private void Btn_Exportar_Click(object sender, EventArgs e)
        {
            try
            {
                var exporter = new ExcelExporter();
                exporter.ExportarOrdenPedido(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(LanguageManager.Traducir("Msg_ErrorGuardando"), ex.Message),
                    LanguageManager.Traducir("Mensaje_Atencion"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private bool HayFiltrosActivos()
        {
            bool filtroFechaDesde = Dtp_FechaDesde.CustomFormat != " ";
            bool filtroFechaHasta = Dtp_FechaHasta.CustomFormat != " ";
            bool filtroEstado = !string.IsNullOrWhiteSpace(Cbx_EstadoPedido.Text);

            return filtroFechaDesde || filtroFechaHasta || filtroEstado;
        }

        private void Btn_LimpiarFiltros_Click(object sender, EventArgs e)
        {
            if (!HayFiltrosActivos())
            {
                MessageBox.Show(
                    LanguageManager.Traducir("NoHayFiltros"),
                    LanguageManager.Traducir("Informacion"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            Dtp_FechaDesde.CustomFormat = " ";
            Dtp_FechaHasta.CustomFormat = " ";
            Cbx_EstadoPedido.SelectedIndex = 0; 

            CargarPedidos();
            Btn_LimpiarFiltros.Enabled = false;
        }
    }
}
