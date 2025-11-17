using BLL.Servicios;
using Domain_Model;
using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.FormsComun.NuevoPedidos
{
    public partial class FormNuevoPedido : Form
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
            Cbx_Cliente.SelectedIndex = -1;
            Cbx_TipoProducto.SelectedIndex = -1;
            Cbx_Nombre.SelectedIndex = -1;
            Cbx_Color.SelectedIndex = -1;
            Cbx_Talle.SelectedIndex = -1;
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
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Insumo", DataPropertyName = "Nombre" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Color", DataPropertyName = "Color_Detalle" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Talle", DataPropertyName = "Talle_Detalle" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cantidad", DataPropertyName = "Cantidad_Detalle" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio Unitario", DataPropertyName = "PrecioUnitario" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Subtotal", DataPropertyName = "Subtotal" });
            dataGridView1.DataSource = _detalles.Select(d => new
            {
                d.IdDetalle,
                d.IdPedido,
                d.IdTela,
                d.Color_Detalle,
                d.Talle_Detalle,
                d.Cantidad_Detalle,
                d.PrecioUnitario,
                Subtotal = d.Cantidad_Detalle * d.PrecioUnitario
            }).ToList();
        }

        private void RefrescarGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _detalles.Select(d => new
            {
                d.IdDetalle,
                d.IdPedido,
                d.IdTela,
                d.Color_Detalle,
                d.Talle_Detalle,
                d.Cantidad_Detalle,
                d.PrecioUnitario,
                Subtotal = d.Cantidad_Detalle * d.PrecioUnitario
            }).ToList();

            var total = _detalles.Sum(d => d.Cantidad_Detalle * d.PrecioUnitario);
            Lbl_PrecioTotal.Text = $"Total: ${total}";
            Lbl_FaltaPagar.Text = $"Falta Pagar: ${total - _adelanto}";
            ActualizarTotales();
        }

        private void FormNuevoPedido_Load(object sender, EventArgs e)
        {

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
            }
            else
            {
                Cbx_Nombre.DataSource = null;
            }
        }

        private void Num_Adelanto_ValueChanged(object sender, EventArgs e)
        {
            _adelanto = (float)Num_Adelanto.Value;
            RefrescarGrid();
        }

        private void Lbl_Nombre_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_Adelanto_Click(object sender, EventArgs e)
        {

        }

        private void Cbx_Nombre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_PrecioTotal_Click(object sender, EventArgs e)
        {

        }

        private void NumPrecioTotal_ValueChanged(object sender, EventArgs e)
        {
            var total = _detalles.Sum(d => d.Cantidad_Detalle * d.PrecioUnitario);
            NumPrecioTotal.Value = (decimal)total;
            NumPrecioTotal.Text = $"Total: ${total}";

        }

        private void Lbl_Cantidad_Click(object sender, EventArgs e)
        {

        }

        private void NuD_Cantidad_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ActualizarTotales()
        {
            var total = _detalles.Sum(d => d.Cantidad_Detalle * d.PrecioUnitario);
            Lbl_PrecioTotal.Text = $"Total: ${total}";
            Lbl_FaltaPagar.Text = $"Falta Pagar: ${total - _adelanto}";
            NumPrecioTotal.Value = (decimal)total;
        }
        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            if (Cbx_Cliente.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                return;
            }

            if (Cbx_Nombre.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un producto.");
                return;
            }

            var detalle = new DetallePedido
            {
                IdTela = (int)Cbx_Nombre.SelectedValue,
                Color_Detalle = Cbx_Color.Text,
                Talle_Detalle = Cbx_Talle.Text,
                Cantidad_Detalle = (int)NuD_Cantidad.Value,
                PrecioUnitario = (float)_insumoService.GetPrecio((int)Cbx_Nombre.SelectedValue),
            };
            _detalles.Add(detalle);
            RefrescarGrid();

        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un detalle para eliminar.");
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
                MessageBox.Show("Seleccione un detalle para editar.");
                return;
            }

            int index = dataGridView1.CurrentRow.Index;
            if (index >= 0 && index < _detalles.Count)
            {
                var detalle = _detalles[index];

                // Cargo los valores en los controles
                Cbx_Nombre.SelectedValue = detalle.IdTela;
                Cbx_Color.Text = detalle.Color_Detalle;
                Cbx_Talle.Text = detalle.Talle_Detalle;
                NuD_Cantidad.Value = detalle.Cantidad_Detalle;

                // Elimino el detalle original mientras lo edito
                _detalles.RemoveAt(index);
                RefrescarGrid();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_Cargar_Click(object sender, EventArgs e)
        {
            var authService = new AuthService();

            Usuario usuarioActual = authService.UsuarioActual; 

            var pedido = new Pedido
            {
                FechaPedido = DateTime.Now,
                FechaEtrega = CalcularFechaEntrega(_detalles),
                IdCliente = (int)Cbx_Cliente.SelectedValue,
                IdEmpleado = usuarioActual?.IdEmpleado ?? 1, // fallback a 1 si no hay usuario
                PrecioTotal = _detalles.Sum(d => d.Cantidad_Detalle * d.PrecioUnitario),
                SaldoPendiente = _detalles.Sum(d => d.Cantidad_Detalle * d.PrecioUnitario) - _adelanto,
                PagoAdelantado = _adelanto > 0
            };

            _pedidoService.GuardarPedido(pedido, _detalles, _adelanto);

            MessageBox.Show("Pedido guardado correctamente");
            this.Close();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Cbx_Cliente.SelectedIndex = -1;
            Cbx_TipoProducto.SelectedIndex = -1;
            Cbx_Nombre.SelectedIndex = -1;
            Cbx_Color.SelectedIndex = -1;
            Cbx_Talle.SelectedIndex = -1;
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
    }
}
