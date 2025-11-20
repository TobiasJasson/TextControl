using BLL.Servicios;
using Domain_Model;
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
using UI.LocalWidget;

namespace UI.FormsComun.NuevoPedidos
{
    public partial class FormNuevoPedido : BaseForm
    {
        private readonly ClienteService _clienteService = new ClienteService();
        private readonly InsumoService _insumoService = new InsumoService();
        private readonly TipoInsumoService _tipoInsumoService = new TipoInsumoService();
        private readonly ColorService _colorService = new ColorService();
        private readonly PedidoService _pedidoService = new PedidoService();
        private List<DetallePedido> _detalles = new List<DetallePedido>();
        private float _adelanto = 0;
        public FormNuevoPedido()
        {
            InitializeComponent();

            CargarCombos();
            ConfigurarDataGridView();
            TraducirUI();
            Cbx_Cliente.SelectedIndex = -1;
            Cbx_TipoProducto.SelectedIndex = -1;
            Cbx_Nombre.SelectedIndex = -1;
            Cbx_Color.SelectedIndex = -1;
            Cbx_Talle.SelectedIndex = -1;
        }

        protected override void TraducirUI()
        {
            this.Text = LanguageManager.Traducir("NuevoPedido_Titulo");

            Lbl_Cliente.Text = LanguageManager.Traducir("NuevoPedido_Cliente");
            Lbl_TipoInsumo.Text = LanguageManager.Traducir("NuevoPedido_TipoProducto");
            Lbl_Nombre.Text = LanguageManager.Traducir("NuevoPedido_NombreProducto");
            Lbl_Color.Text = LanguageManager.Traducir("NuevoPedido_Color");
            Lbl_Talle.Text = LanguageManager.Traducir("NuevoPedido_Talle");
            Lbl_Cantidad.Text = LanguageManager.Traducir("NuevoPedido_Cantidad");
            Lbl_Adelanto.Text = LanguageManager.Traducir("NuevoPedido_Adelanto");
            Lbl_PrecioTotal.Text = LanguageManager.Traducir("NuevoPedido_PrecioTotal");
            Lbl_FaltaPagar.Text = LanguageManager.Traducir("NuevoPedido_FaltaPagar");
            
            Lbl_FaltaPagarResult.Text = LanguageManager.Traducir("NuevoPedido_FaltaPagarResultPrefix") + " " + Lbl_FaltaPagarResult.Text;

            Btn_Agregar.Text = LanguageManager.Traducir("NuevoPedido_BtnAgregar");
            Btn_Eliminar.Text = LanguageManager.Traducir("NuevoPedido_BtnEliminar");
            Btn_Editar.Text = LanguageManager.Traducir("NuevoPedido_BtnEditar");
            Btn_Cargar.Text = LanguageManager.Traducir("NuevoPedido_BtnCargar");
            Btn_Cancelar.Text = LanguageManager.Traducir("NuevoPedido_BtnCancelar");

            TraducirColumnas();
        }


        private void TraducirColumnas()
        {
            if (dataGridView1.Columns.Count == 0)
                return;

            SetColHeader("colInsumo", "NuevoPedido_Col_Insumo");
            SetColHeader("colColor", "NuevoPedido_Col_Color");
            SetColHeader("colTalle", "NuevoPedido_Col_Talle");
            SetColHeader("colCantidad", "NuevoPedido_Col_Cantidad");
            SetColHeader("colPU", "NuevoPedido_Col_PrecioUnitario");
            SetColHeader("colSubtotal", "NuevoPedido_Col_Subtotal");
            SetColHeader("colAdelanto", "NuevoPedido_Col_Adelanto");
            SetColHeader("colFalta", "NuevoPedido_Col_FaltaPagar");
        }

        private void SetColHeader(string colName, string multiKey)
        {
            if (dataGridView1.Columns.Contains(colName))
                dataGridView1.Columns[colName].HeaderText = LanguageManager.Traducir(multiKey);
        }

        private void CargarCombos()
        {
            // Clientes
            Cbx_Cliente.DataSource = _clienteService.GetAll();
            Cbx_Cliente.DisplayMember = "Nombre_Cliente";
            Cbx_Cliente.ValueMember = "ID_Cliente";

            // Tipo de Insumo
            Cbx_TipoProducto.DataSource = _tipoInsumoService.ObtenerTodos();
            Cbx_TipoProducto.DisplayMember = "Descripcion"; 
            Cbx_TipoProducto.ValueMember = "ID_TipoInsumo";

            // Insumos
            Cbx_Nombre.DataSource = _insumoService.ObtenerStock();
            Cbx_Nombre.DisplayMember = "Nombre";
            Cbx_Nombre.ValueMember = "ID_Insumo";

            // Colores
            Cbx_Color.DataSource = _colorService.ObtenerTodosLosColores();
            Cbx_Color.DisplayMember = "Descripcion";
            Cbx_Color.ValueMember = "ID_Color";

            // Talles
            Cbx_Talle.DataSource = _insumoService.GetAllTalles();
            Cbx_Talle.DisplayMember = "Detalle";
            Cbx_Talle.ValueMember = "ID_Talle";
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "colInsumo", HeaderText = LanguageManager.Traducir("NuevoPedido_Col_Insumo"), DataPropertyName = "Nombre" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "colColor", HeaderText = LanguageManager.Traducir("NuevoPedido_Col_Color"), DataPropertyName = "Color_Detalle" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTalle", HeaderText = LanguageManager.Traducir("NuevoPedido_Col_Talle"), DataPropertyName = "Talle_Detalle" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCantidad", HeaderText = LanguageManager.Traducir("NuevoPedido_Col_Cantidad"), DataPropertyName = "Cantidad_Detalle" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPU", HeaderText = LanguageManager.Traducir("NuevoPedido_Col_PrecioUnitario"), DataPropertyName = "PrecioUnitario" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSubtotal", HeaderText = LanguageManager.Traducir("NuevoPedido_Col_Subtotal"), DataPropertyName = "Subtotal" });

            if (_adelanto > 0)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAdelanto", HeaderText = LanguageManager.Traducir("NuevoPedido_Col_Adelanto"), DataPropertyName = "Adelanto" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFalta", HeaderText = LanguageManager.Traducir("NuevoPedido_Col_FaltaPagar"), DataPropertyName = "FaltaPagar" });
            }

            RefrescarGrid();
        }

        private void RefrescarGrid()
        {
            float total = _detalles.Sum(d => d.Cantidad_Detalle * d.PrecioUnitario);

            dataGridView1.DataSource = null;

            dataGridView1.DataSource = _detalles.Select(d => new
            {
                d.IdDetalle,
                d.IdPedido,
                d.IdTela,
                d.Nombre,
                d.Color_Detalle,
                d.Talle_Detalle,
                d.Cantidad_Detalle,
                d.PrecioUnitario,
                Subtotal = d.Cantidad_Detalle * d.PrecioUnitario,
                Adelanto = _adelanto,
                FaltaPagar = total - _adelanto
            }).ToList();

            ActualizarTotales();
        }

        private void FormNuevoPedido_Load(object sender, EventArgs e)
        {
            TraducirColumnas();
            TraducirUI();
        }
        private void Lbl_Cliente_Click(object sender, EventArgs e)
        {

        }

        private void Cbx_Cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_Talle_Click(object sender, EventArgs e)
        {

        }

        private void Cbx_Talle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_TipoInsumo_Click(object sender, EventArgs e)
        {

        }

        private void Cbx_TipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbx_TipoProducto.SelectedValue is int tipoId)
            {
                var insumosFiltrados = _insumoService.ObtenerStock()
                       .Where(i => i.ID_TipoInsumo == tipoId)
                       .ToList();

                Cbx_Nombre.DataSource = insumosFiltrados;
                Cbx_Nombre.DisplayMember = "Nombre";
                Cbx_Nombre.ValueMember = "ID_Insumo";
                Cbx_Nombre.SelectedIndex = -1;

                Cbx_Color.DataSource = null;
            }
            else
            {
                Cbx_Nombre.DataSource = null;
            }
        }
        private void Lbl_Nombre_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_Adelanto_Click(object sender, EventArgs e)
        {

        }

        private void Cbx_Nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbx_Nombre.SelectedValue is int idInsumo)
            {
                var colores = _insumoService.ObtenerColoresPorInsumo(idInsumo);
                Cbx_Color.DataSource = colores;
                Cbx_Color.DisplayMember = "Descripcion";
                Cbx_Color.ValueMember = "ID_Color";
                Cbx_Color.SelectedIndex = -1;
            }
        }

        private void Lbl_PrecioTotal_Click(object sender, EventArgs e)
        {

        }

        private void NumPrecioTotal_ValueChanged(object sender, EventArgs e)
        {
            var total = _detalles.Sum(d => d.Cantidad_Detalle * d.PrecioUnitario);
            Txt_PrecioTotalResult.Text = $" ${(decimal)total}";

        }

        private void Lbl_Cantidad_Click(object sender, EventArgs e)
        {

        }

        private void NuD_Cantidad_ValueChanged(object sender, EventArgs e)
        {
            if (Cbx_Nombre.SelectedValue != null)
            {
                float precio = (float)_insumoService.GetPrecio((int)Cbx_Nombre.SelectedValue);
                float subtotal = precio * (int)NuD_Cantidad.Value;

                Txt_PrecioTotalResult.Text = $"${subtotal:N2}";
            }
        }

        private void ActualizarTotales()
        {
            float total = _detalles.Sum(d => d.Cantidad_Detalle * d.PrecioUnitario);

            Txt_PrecioTotalResult.Text = $"${total:N2}";
            if(_adelanto > 0)
            {

            Lbl_FaltaPagarResult.Text = $"${(_adelanto - total):N2}";
            }
            else
            {
                Lbl_FaltaPagarResult.Text = $"${(total):N2}";
            }
        }
        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cbx_Cliente.SelectedValue == null)
                    throw new Exception(LanguageManager.Traducir("NuevoPedido_Msg_SeleccionarCliente"));

                if (Cbx_Nombre.SelectedValue == null)
                    throw new Exception(LanguageManager.Traducir("NuevoPedido_Msg_SeleccionarProducto"));

                if (Cbx_Color.SelectedValue == null)
                    throw new Exception(LanguageManager.Traducir("NuevoPedido_Msg_SeleccionarColor"));

                if (Cbx_Talle.SelectedValue == null)
                    throw new Exception(LanguageManager.Traducir("NuevoPedido_Msg_SeleccionarTalle"));

                if (NuD_Cantidad.Value <= 0)
                    throw new Exception(LanguageManager.Traducir("NuevoPedido_Msg_CantidadMayorCero"));

                int idInsumo = (int)Cbx_Nombre.SelectedValue;
                float precio = (float)_insumoService.GetPrecio(idInsumo);

                if (precio <= 0)
                    throw new Exception(LanguageManager.Traducir("NuevoPedido_Msg_PrecioInvalido"));

                var detalle = new DetallePedido
                {
                    IdTela = idInsumo,
                    Nombre = Cbx_Nombre.Text,
                    Color_Detalle = Cbx_Color.Text,
                    Talle_Detalle = Cbx_Talle.Text,
                    IdTalle = Cbx_Talle.SelectedValue is int v ? v : 0,
                    Cantidad_Detalle = (int)NuD_Cantidad.Value,
                    PrecioUnitario = precio
                };

                _detalles.Add(detalle);

                RefrescarGrid();

                NuD_Cantidad.Value = 1;
                Cbx_Talle.SelectedIndex = -1;
                Cbx_Color.SelectedIndex = -1;

                MessageBox.Show(
                    LanguageManager.Traducir("NuevoPedido_Msg_DetalleAgregado"),
                    LanguageManager.Traducir("Mensaje_Exito"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    LanguageManager.Traducir("Mensaje_Error"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show(LanguageManager.Traducir("NuevoPedido_Msg_SeleccionarDetalleEliminar"),
                    LanguageManager.Traducir("Mensaje_Advertencia"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int index = dataGridView1.CurrentRow.Index;
            if (index >= 0 && index < _detalles.Count)
            {
                _detalles.RemoveAt(index);
                RefrescarGrid();
            }
        }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show(LanguageManager.Traducir("NuevoPedido_Msg_ConfirmarEliminar"),
                    LanguageManager.Traducir("Mensaje_Confirmacion"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                return;
            }

            int index = dataGridView1.CurrentRow.Index;

            if (index < 0 || index >= _detalles.Count)
                return;

            var detalle = _detalles[index];

            Cbx_Nombre.SelectedValue = detalle.IdTela;
            Cbx_Color.Text = detalle.Color_Detalle;
            Cbx_Talle.Text = detalle.Talle_Detalle;
            NuD_Cantidad.Value = detalle.Cantidad_Detalle;

            _detalles.RemoveAt(index);
            RefrescarGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_Cargar_Click(object sender, EventArgs e)
        {

            if (_detalles.Count == 0)
            {
                MessageBox.Show(LanguageManager.Traducir("NuevoPedido_Msg_AgregarProductoAntesDeCargar"),
                    LanguageManager.Traducir("Mensaje_Advertencia"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (Cbx_Cliente.SelectedValue == null)
            {
                MessageBox.Show(LanguageManager.Traducir("NuevoPedido_Msg_SeleccionarCliente"),
                    LanguageManager.Traducir("Mensaje_Advertencia"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var authService = new AuthService();
            Usuario usuarioActual = authService.UsuarioActual;

            float total = _detalles.Sum(d => d.Cantidad_Detalle * d.PrecioUnitario);

            var pedido = new Pedido
            {
                FechaPedido = DateTime.Now,
                FechaEtrega = CalcularFechaEntrega(_detalles),
                IdCliente = (int)Cbx_Cliente.SelectedValue,
                IdEmpleado = usuarioActual?.IdEmpleado ?? 1,
                PrecioTotal = total,
                SaldoPendiente = _adelanto - total,
                PagoAdelantado = _adelanto > 0
            };

            _pedidoService.GuardarPedido(pedido, _detalles, _adelanto);

            MessageBox.Show(LanguageManager.Traducir("NuevoPedido_Msg_PedidoGuardado"),
                LanguageManager.Traducir("Mensaje_Exito"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            this.Close();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Cbx_Cliente.SelectedIndex = -1;
            Cbx_TipoProducto.SelectedIndex = -1;
            Cbx_Nombre.SelectedIndex = -1;
            Cbx_Color.SelectedIndex = -1;
            Cbx_Talle.SelectedIndex = -1;

            NuD_Cantidad.Value = 1;
            Txt_Adelanto.Text = "";

            _detalles.Clear();
            _adelanto = 0;

            RefrescarGrid();
        }

        private void Lbl_Color_Click(object sender, EventArgs e)
        {

        }

        private void Cbx_Color_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_FaltaPagar_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_FaltaPagarResult_Click(object sender, EventArgs e)
        {
            ActualizarTotales();
        }

        private DateTime CalcularFechaEntrega(List<DetallePedido> detalles)
        {
            if (detalles == null || detalles.Count == 0)
                return DateTime.Now.AddDays(60);

            int totalCantidad = detalles.Sum(d => d.Cantidad_Detalle);
            int cantidadDetalles = detalles.Count;

            double diasPorCantidad = (totalCantidad / 10.0) * 15;

            double diasPorDetalles = cantidadDetalles * 10;

            int diasTotales = (int)Math.Ceiling(diasPorCantidad + diasPorDetalles);

            if (diasTotales < 30) diasTotales = 30;
            if (diasTotales > 180) diasTotales = 180;

            return DateTime.Now.AddDays(diasTotales);
        }

        private void Txt_PrecioTotalResult_TextChanged(object sender, EventArgs e)
        {
            Txt_PrecioTotalResult.ReadOnly = true;
            Txt_PrecioTotalResult.TabStop = false;
        }

        private void Txt_Adelanto_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_Adelanto.Text))
            {
                _adelanto = 0;
                ActualizarTotales();
                return;
            }

            if (float.TryParse(Txt_Adelanto.Text, out float valor))
            {
                bool teniaAdelantoAntes = _adelanto > 0;

                _adelanto = valor;
                ActualizarTotales();
                bool tieneAdelantoAhora = _adelanto > 0;
                if (teniaAdelantoAntes != tieneAdelantoAhora)
                {
                    ConfigurarDataGridView();
                }
            }
            else
            {
                Txt_Adelanto.Text = _adelanto.ToString();
                Txt_Adelanto.SelectionStart = Txt_Adelanto.Text.Length;
            }
        }
    }
}
