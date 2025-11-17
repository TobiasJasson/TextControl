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
using UI.LocalWidget;

namespace UI.FormsComun.OrdenesPedidos
{
    public partial class FormDetallesPedidos : BaseForm
    {
        private readonly int _idPedido;
        private readonly List<PedidoDTO> _detalles;
        public FormDetallesPedidos(int idPedido, List<PedidoDTO> detalles)
        {
            ThemeManager.LoadTheme();
            InitializeComponent();
            _idPedido = idPedido;
            _detalles = detalles;
        }
        private void FormDetallesPedidos_Load(object sender, EventArgs e)
        
        {
            ThemeManager.LoadTheme();
            TraducirUI();
            CargarInfoCabecera();
            CargarDetalles();
            if (ThemeManager.ModoOscuro)
            {
                foreach (var lbl in this.Controls.OfType<Label>())
                    lbl.ForeColor = Color.Silver;
            }
            else
            {
                foreach (var lbl in this.Controls.OfType<Label>())
                    lbl.ForeColor = Color.Black;
            }
        }

        private void CargarInfoCabecera()
        {
            var p = _detalles.First();

            Lbl_PedidoResultado.Text = p.ID_pedido.ToString();
            Lbl_ClienteResult.Text = p.Nombre_Cliente;
            Lbl_FechaResult.Text = p.FechaPedido.ToString("dd/MM/yyyy");
            Lbl_EstadoResult.Text = p.EstadoPedido;

            double total = p.PrecioTotal_pedido;
            double adelanto = p.pagoAdelanto_pedido ? p.TotalPagosAdelantados : 0;
            double pendiente = total - adelanto;

            Lbl_TotalResult.Text = "$ " + total.ToString("N2");

            Lbl_AdelantoResult.Text = p.pagoAdelanto_pedido
                ? "$ " + adelanto.ToString("N2")
                : "-";

            Lbl_FaltaPagarResult.Text = "$ " + pendiente.ToString("N2");
        }

        private void CargarDetalles()
        {
            var detalleParaGrid = _detalles.Select(d => new
            {
                Cantidad = d.Cantidad_Detalle,
                Talle = d.Detalles_Talles,
                Color = d.Color_Detalle,
                Precio = d.Precio_Detalle,
                Subtotal = d.Cantidad_Detalle * d.Precio_Detalle
            }).ToList();

            Dgv_DetallePedido.DataSource = detalleParaGrid;

            Dgv_DetallePedido.Columns["Precio"].DefaultCellStyle.Format = "C2";
            Dgv_DetallePedido.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            Dgv_DetallePedido.Columns["Precio"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("es-AR");
            Dgv_DetallePedido.Columns["Subtotal"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("es-AR");

            Dgv_DetallePedido.ReadOnly = true;
            Dgv_DetallePedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        protected override void TraducirUI()
        {
            this.Text = LanguageManager.Traducir("DetallePedidoTitulo");
            Lbl_Pedido.Text = LanguageManager.Traducir("Pedido_ID");
            Lbl_Cliente.Text = LanguageManager.Traducir("Cliente");
            Lbl_Fecha.Text = LanguageManager.Traducir("FechaPedido");
            Lbl_Estado.Text = LanguageManager.Traducir("EstadoPedido");
            Lbl_Total.Text = LanguageManager.Traducir("Total_Precio");
            Btn_Volver.Text = LanguageManager.Traducir("Volver");
            Lbl_Adelanto.Text = LanguageManager.Traducir("Pago_Adelanto");
            Lbl_FaltaPagar.Text = LanguageManager.Traducir("Total_Pendiente");

            if (Dgv_DetallePedido.Columns.Count > 0)
            {
                Dgv_DetallePedido.Columns["Cantidad"].HeaderText = LanguageManager.Traducir("Cantidad");
                Dgv_DetallePedido.Columns["Talle"].HeaderText = LanguageManager.Traducir("Talle");
                Dgv_DetallePedido.Columns["Color"].HeaderText = LanguageManager.Traducir("Color");
                Dgv_DetallePedido.Columns["Precio"].HeaderText = LanguageManager.Traducir("PrecioUnitario");
                Dgv_DetallePedido.Columns["Subtotal"].HeaderText = LanguageManager.Traducir("Subtotal");
            }
        }



        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            MainScreen mainScreen = Navigator.GetMain(this);
            if (mainScreen == null) { Close(); return; }

            FormOrdenesPedidos form = new FormOrdenesPedidos()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            mainScreen.lblTitle.Text = LanguageManager.Traducir("SideMenu_Reporte");

            mainScreen.panelContenido.Controls.Clear();
            mainScreen.panelContenido.Controls.Add(form);

            ThemeManager.ApplyTheme(form, ThemeManager.ModoOscuro);

            form.Show();
        }


        private void Lbl_Fecha_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_PedidoResultado_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_FechaResult_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_Cliente_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_ClienteResult_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_Estado_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_EstadoResult_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_Total_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_TotalResult_Click(object sender, EventArgs e)
        {

        }

        private void Dgv_DetallePedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Lbl_AdelantoResult_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_FaltaPagarResult_Click(object sender, EventArgs e)
        {

        }
    }
}
