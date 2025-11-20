using BLL.Servicios;
using Domain_Model;
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
using UI.LocalWidget;

namespace UI.FormsComun.Clientes
{
    public partial class FormClientes : BaseForm
    {
        private readonly ClienteService _clienteService = new ClienteService();
        private bool _modoEdicion = false;
        private int _filaEditando = -1;
        private int _idSeleccionado = 0;
        public FormClientes()
        {
            ThemeManager.LoadTheme();
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            ConfigurarLayoutResponsive();
        }

        private void CargarClientes()
        {
            try
            {
                var lista = _clienteService.GetAll();

                dataGridView1.DataSource = lista.Select(c => new
                {
                    Nombre = c.Nombre_Cliente,
                    Contacto = c.Contacto_Cliente,
                    Email = c.Email_Cliente,
                    ID_Cliente = c.ID_Cliente
                }).ToList();

                FormatearGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(LanguageManager.Traducir("Cliente_Error_Cargar") + ex.Message);
            }
        }

        private void FormatearGrid()
        {
            if (dataGridView1.Columns["ID_Cliente"] != null)
                dataGridView1.Columns["ID_Cliente"].Visible = false;

            dataGridView1.ClearSelection();
        }

        private void Txt_NombreCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_ContactoCliente_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_NombreEmpleado_Click(object sender, EventArgs e)
        {

        }

        private void Txt_ContactoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_EmailCliente_Click(object sender, EventArgs e)
        {

        }

        private void Txt_EmailCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();

                var cliente = new Cliente
                {
                    Nombre_Cliente = Txt_NombreCliente.Text.Trim(),
                    Contacto_Cliente = Txt_ContactoCliente.Text.Trim(),
                    Email_Cliente = Txt_EmailCliente.Text.Trim()
                };

                _clienteService.AgregarCliente(cliente);

                MessageBox.Show(LanguageManager.Traducir("Cliente_Agregado"));

                CargarClientes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(LanguageManager.Traducir("Cliente_Error_Agregar") + ex.Message);
            }
        }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            if (!_modoEdicion)
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show(LanguageManager.Traducir("Cliente_Seleccion_Editar"));
                    return;
                }

                _filaEditando = dataGridView1.SelectedRows[0].Index;
                _modoEdicion = true;
                dataGridView1.ReadOnly = false;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                    row.ReadOnly = row.Index != _filaEditando;

                var fila = dataGridView1.Rows[_filaEditando];
                Txt_NombreCliente.Text = fila.Cells["Nombre"].Value?.ToString();
                Txt_ContactoCliente.Text = fila.Cells["Contacto"].Value?.ToString();
                Txt_EmailCliente.Text = fila.Cells["Email"].Value?.ToString();

                Btn_Editar.Text = LanguageManager.Traducir("Boton_Actualizar");
            }
            else
            {
                try
                {
                    var fila = dataGridView1.Rows[_filaEditando];

                    var cliente = new Cliente
                    {
                        ID_Cliente = Convert.ToInt32(fila.Cells["ID_Cliente"].Value),
                        Nombre_Cliente = Txt_NombreCliente.Text.ToString(),
                        Contacto_Cliente = Txt_ContactoCliente.Text.ToString(),
                        Email_Cliente = Txt_EmailCliente.Text.ToString(),
                    };

                    _clienteService.EditarCliente(cliente);

                    MessageBox.Show(LanguageManager.Traducir("Cliente_Actualizado"));

                    _modoEdicion = false;
                    dataGridView1.ReadOnly = true;
                    Btn_Editar.Text = LanguageManager.Traducir("Boton_Editar");

                    CargarClientes();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(LanguageManager.Traducir("Cliente_Error_Actualizar") + ex.Message);
                }
            }
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show(LanguageManager.Traducir("Msg_SeleccionEliminar"));
                    return;
                }

                var fila = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(fila.Cells["ID_Cliente"].Value);

                if (MessageBox.Show(
                    LanguageManager.Traducir("Msg_ConfirmarEliminar"),
                    LanguageManager.Traducir("Mensaje_Confirmacion"),
                    MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                _clienteService.EliminarCliente(id);

                MessageBox.Show(LanguageManager.Traducir("Msg_EliminadoCorrectamente"));

                CargarClientes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(LanguageManager.Traducir("Cliente_Error_Eliminar") + ex.Message);
            }
        }
        private void ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(Txt_NombreCliente.Text))
                throw new Exception("Debe ingresar un nombre.");

            if (string.IsNullOrWhiteSpace(Txt_EmailCliente.Text))
                throw new Exception("Debe ingresar un email.");
        }
        private void LimpiarCampos()
        {
            Txt_NombreCliente.Text = "";
            Txt_ContactoCliente.Text = "";
            Txt_EmailCliente.Text = "";

            _modoEdicion = false;
            _idSeleccionado = 0;
            _filaEditando = -1;

            Btn_Editar.Text = LanguageManager.Traducir("Boton_Editar");
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (_modoEdicion)
            {
                if (_filaEditando >= 0)
                    dataGridView1.Rows[_filaEditando].Selected = true;
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                LimpiarCampos();
                return;
            }

            var row = dataGridView1.SelectedRows[0];

            Txt_NombreCliente.Text = row.Cells["Nombre"].Value?.ToString();
            Txt_ContactoCliente.Text = row.Cells["Contacto"].Value?.ToString();
            Txt_EmailCliente.Text = row.Cells["Email"].Value?.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            Txt_NombreCliente.Text = row.Cells["Nombre"].Value?.ToString();
            Txt_ContactoCliente.Text = row.Cells["Contacto"].Value?.ToString();
            Txt_EmailCliente.Text = row.Cells["Email"].Value?.ToString();

        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
            LimpiarCampos();
            this.Shown += (s, e2) =>
            {
                TraducirUI();
            };

        }

        protected override void TraducirUI()
        {
            this.Text = LanguageManager.Traducir("SideMenu_Cliente");
            Btn_Agregar.Text = LanguageManager.Traducir("Boton_Agregar");
            Btn_Editar.Text = LanguageManager.Traducir("Boton_Editar");
            Btn_Eliminar.Text = LanguageManager.Traducir("Boton_Eliminar");

            Lbl_NombreCliente.Text = LanguageManager.Traducir("Col_Nombre");
            Lbl_ContactoCliente.Text = LanguageManager.Traducir("Col_Contacto");
            Lbl_EmailCliente.Text = LanguageManager.Traducir("Col_Email");

            // Traducción de columnas del GRID
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["Nombre"].HeaderText = LanguageManager.Traducir("Col_Nombre");
                dataGridView1.Columns["Contacto"].HeaderText = LanguageManager.Traducir("Col_Contacto");
                dataGridView1.Columns["Email"].HeaderText = LanguageManager.Traducir("Col_Email");
            }
        }

        private void ConfigurarLayoutResponsive()
        {
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 1
            };

            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var panelBotones = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Dock = DockStyle.Top,
                Padding = new Padding(10)
            };

            panelBotones.Controls.Add(Btn_Agregar);
            panelBotones.Controls.Add(Btn_Editar);
            panelBotones.Controls.Add(Btn_Eliminar);

            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            var panelCampos = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 6,
                AutoSize = true,
                Padding = new Padding(15)
            };

            panelCampos.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panelCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            panelCampos.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); 
            panelCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33)); 
            panelCampos.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panelCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33)); 

            Lbl_NombreCliente.ForeColor = Color.Silver;
            Lbl_ContactoCliente.ForeColor = Color.Silver;
            Lbl_EmailCliente.ForeColor = Color.Silver;

            Txt_NombreCliente.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Txt_ContactoCliente.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Txt_EmailCliente.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            panelCampos.Controls.Add(Lbl_NombreCliente, 0, 0);
            panelCampos.Controls.Add(Txt_NombreCliente, 1, 0);

            panelCampos.Controls.Add(Lbl_ContactoCliente, 2, 0);
            panelCampos.Controls.Add(Txt_ContactoCliente, 3, 0);

            panelCampos.Controls.Add(Lbl_EmailCliente, 4, 0);
            panelCampos.Controls.Add(Txt_EmailCliente, 5, 0);

            layout.Controls.Add(panelBotones, 0, 0);
            layout.Controls.Add(dataGridView1, 0, 1);
            layout.Controls.Add(panelCampos, 0, 2);

            this.Controls.Clear();
            this.Controls.Add(layout);
        }
    }
}
