using BLL.Interfaces;
using BLL.Servicios;
using DomainModel;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UI.FormsComun.Admin
{
    public partial class FormControlEmpleado : BaseForm
    {
        private UsuarioService _servicio;
        private int _idEditar = 0;
        private string idUsuario;
        public FormControlEmpleado()
        {
            InitializeComponent();
            _servicio = new UsuarioService();
        }

        private void FormControlEmpleado_Load(object sender, EventArgs e)
        {
            _servicio = new UsuarioService();
            TraducirUI();
            OcultarPanelEdicion();
            CargarGrid();

            Cbx_RolEmpleado.Items.Clear();
            Cbx_RolEmpleado.Items.Add(string.Empty);
            Cbx_RolEmpleado.Items.Add("Administrativo");
            Cbx_RolEmpleado.Items.Add("Empleado");
            Cbx_RolEmpleado.SelectedIndex = 0;
        }

        public void CargarGrid()
        {
            var dt = _servicio.ObtenerGrid();

            var tabla = dt.AsEnumerable().Select(u => new
            {
                Nombre = u["Nombre_Empleado"]?.ToString(),
                Apellido = u["Apellido_Empleado"]?.ToString(),
                Email = u["Email"]?.ToString(),
                Contacto = u["Contacto"]?.ToString(),
                Rol = u["NombreRol"]?.ToString(),
                DNI = u["DNI_Empleado"]?.ToString(),
                UsuarioActivo = (bool)u["UsuarioActivo"] ? LanguageManager.Traducir("Activo") : LanguageManager.Traducir("Inactivo"),
                ID_Usuario = (int)u["ID_Usuario"],
                ID_Empleado = (int)u["ID_Empleado"]
            }).ToList();

            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.DataSource = tabla;
                    FormatearGrid();
                }));
            }
            else
            {
                dataGridView1.DataSource = tabla;
                FormatearGrid();
            }
        }

        private void FormatearGrid()
        {
            if (dataGridView1.Columns["ID_Usuario"] != null)
                dataGridView1.Columns["ID_Usuario"].Visible = false;

            if (dataGridView1.Columns["ID_Empleado"] != null)
                dataGridView1.Columns["ID_Empleado"].Visible = false;

            dataGridView1.AutoResizeColumns();
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                _idEditar = 0;
                OcultarPanelEdicion();
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            _idEditar = Convert.ToInt32(row.Cells["ID_Usuario"].Value);

            MostrarPanelEdicion();
            Btn_GuardarEmpleado.Text = LanguageManager.Traducir("Boton_Actualizar");

            Txt_NombreEmpleado.Text = row.Cells["Nombre"].Value.ToString();
            Txt_ApellidoEmpleado.Text = row.Cells["Apellido"].Value.ToString();
            Txt_EmailEmpleado.Text = row.Cells["Email"].Value.ToString();
            Txt_NumeroEmpleado.Text = row.Cells["Contacto"].Value.ToString();
            Txt_DniEmpleado.Text = row.Cells["DNI"].Value.ToString();
            Cbx_RolEmpleado.SelectedIndex = (row.Cells["Rol"].Value.ToString() == LanguageManager.Traducir("Administrativo")) ? 0 : 1;
            Switch_Activo.Checked = row.Cells["UsuarioActivo"].Value.ToString() == LanguageManager.Traducir("Activo");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            _idEditar = 0;
            idUsuario = null;
            MostrarPanelEdicion();
            HabilitarEdicion(true);
            Btn_GuardarEmpleado.Text = LanguageManager.Traducir("Boton_Agregar");
            Txt_NombreEmpleado.Clear();
            Txt_ApellidoEmpleado.Clear();
            Txt_EmailEmpleado.Clear();
            Txt_NumeroEmpleado.Clear();
            Txt_DniEmpleado.Clear();
            Cbx_RolEmpleado.SelectedIndex = 0;
            Switch_Activo.Checked = true;
        }

        private bool ValidarCamposRequeridos(out string mensajeFaltantes)
        {
            var faltantes = new List<string>();

            if (string.IsNullOrWhiteSpace(Txt_NombreEmpleado.Text))
                faltantes.Add(LanguageManager.Traducir("Lbl_NombreEmpleado"));

            if (string.IsNullOrWhiteSpace(Txt_ApellidoEmpleado.Text))
                faltantes.Add(LanguageManager.Traducir("Lbl_ApellidoEmpleado"));

            if (string.IsNullOrWhiteSpace(Txt_DniEmpleado.Text))
                faltantes.Add(LanguageManager.Traducir("Lbl_DniEmpleado"));

            if (string.IsNullOrWhiteSpace(Txt_EmailEmpleado.Text))
                faltantes.Add(LanguageManager.Traducir("Lbl_Email"));

            if (Cbx_RolEmpleado.SelectedIndex <= 0)
                faltantes.Add(LanguageManager.Traducir("Lbl_RolEmpleado"));

            if (faltantes.Any())
            {
                mensajeFaltantes = string.Join("\n", faltantes);
                return false;
            }

            mensajeFaltantes = string.Empty;
            return true;
        }
        private void Btn_Editar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un usuario para editar.");
                return;
            }
            //_idEditar = 0;
            MostrarPanelEdicion();
            var row = dataGridView1.SelectedRows[0];

            _idEditar = Convert.ToInt32(row.Cells["ID_Usuario"].Value);
            idUsuario = _idEditar.ToString();
            int idEmpleado = Convert.ToInt32(row.Cells["ID_Empleado"].Value);
            //idUsuario = row.Cells["ID_Usuario"].Value.ToString();
            Txt_NombreEmpleado.Text = row.Cells["Nombre"].Value.ToString();
            Txt_ApellidoEmpleado.Text = row.Cells["Apellido"].Value.ToString();
            Txt_DniEmpleado.Text = row.Cells["DNI"].Value.ToString();
            Txt_EmailEmpleado.Text = row.Cells["Email"].Value.ToString();
            Txt_NumeroEmpleado.Text = row.Cells["Contacto"].Value.ToString();

            string activoStr = row.Cells["UsuarioActivo"].Value.ToString();
            Switch_Activo.Checked = (activoStr == "Activo");

            string rol = row.Cells["Rol"].Value.ToString();

            Cbx_RolEmpleado.SelectedItem = rol; 

            HabilitarEdicion(true);
        }

        private void HabilitarEdicion(bool valor)
        {
            Txt_NombreEmpleado.ReadOnly = !valor;
            Txt_ApellidoEmpleado.ReadOnly = !valor;
            Txt_DniEmpleado.ReadOnly = !valor;
            Txt_EmailEmpleado.ReadOnly = !valor;
            Txt_NumeroEmpleado.ReadOnly = !valor;
            Switch_Activo.Enabled = valor;
            Cbx_RolEmpleado.Enabled = valor;
            Btn_GuardarEmpleado.Enabled = valor; 
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Usuario"].Value);

            if (MessageBox.Show("¿Seguro que deseas eliminar este usuario?",
                               "Confirmar",
                               MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _servicio.Eliminar(id);
                CargarGrid();
            }
        }

        private void Lbl_NombreEmpleado_Click(object sender, EventArgs e)
        {

        }

        private void Txt_NombreEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_ApellidoEmpleado_Click(object sender, EventArgs e)
        {

        }

        private void Txt_ApellidoEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_DniEmpleado_Click(object sender, EventArgs e)
        {

        }

        private void Txt_DniEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_Email_Click(object sender, EventArgs e)
        {

        }

        private void Txt_EmailEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_NumeroEmpleado_Click(object sender, EventArgs e)
        {

        }

        private void Txt_NumeroEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_RolEmpleado_Click(object sender, EventArgs e)
        {

        }

        private void Cbx_RolEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_Activo_Click(object sender, EventArgs e)
        {

        }

        private void Btn_GuardarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCamposRequeridos(out string faltantes))
                {
                    string mensaje = string.Format(LanguageManager.Traducir("Msg_CamposRequeridos"), faltantes);
                    MessageBox.Show(mensaje, LanguageManager.Traducir("Msg_ErrorGuardando"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Empleado emp = new Empleado()
                {
                    Nombre = Txt_NombreEmpleado.Text,
                    Apellido = Txt_ApellidoEmpleado.Text,
                    DNI = Txt_DniEmpleado.Text,
                    Gmail = Txt_EmailEmpleado.Text,
                    Contacto = Txt_NumeroEmpleado.Text
                };

                bool activo = Switch_Activo.Checked;
                int idRol = GetRolIdFromCombo();

                if (_idEditar == 0)
                {
                Usuario usu = new Usuario()
                {
                    UserName = emp.Nombre,
                    Password = Convert.ToBase64String(Encoding.UTF8.GetBytes("claveTemporal")),
                    EmailRecuperacion = emp.Gmail,
                    Activo = activo
                };

                int idCreado = _servicio.CrearEmpleado(emp, usu, idRol);

                string token = UsuarioService.GenerateToken();

                var emailService = new EmailService();
                emailService.EnviarBienvenida(emp, usu.UserName, idCreado, token);

                MessageBox.Show(LanguageManager.Traducir("Msg_EmpleadoCreado"));
            }
            else
            {
                Usuario usu = new Usuario()
                {
                    UserName = emp.Nombre,
                    Password = Convert.ToBase64String(Encoding.UTF8.GetBytes("claveTemporal")),
                    EmailRecuperacion = emp.Gmail,
                    Activo = activo
                };

                int idUsu = Convert.ToInt32(idUsuario);

                _servicio.ActualizarEmpleado(idUsu, emp, idRol, activo, usu);
                MessageBox.Show(LanguageManager.Traducir("Msg_EmpleadoEditadoCorrectamente"));
            }

            CargarGrid();
            HabilitarEdicion(false);
            OcultarPanelEdicion();
            }
            catch (Exception ex)
            {
                string mensaje = string.Format(LanguageManager.Traducir("Msg_ErrorGuardando"), ex.Message);
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       
        }
        private int GetRolIdFromCombo()
        {
            if (Cbx_RolEmpleado.SelectedIndex == 1) return 1;
            if (Cbx_RolEmpleado.SelectedIndex == 2) return 2;
            return 0;
        }

        protected override void TraducirUI()
        {
            // Labels
            Lbl_NombreEmpleado.Text = LanguageManager.Traducir("Lbl_NombreEmpleado");
            Lbl_ApellidoEmpleado.Text = LanguageManager.Traducir("Lbl_ApellidoEmpleado");
            Lbl_DniEmpleado.Text = LanguageManager.Traducir("Lbl_DniEmpleado");
            Lbl_Email.Text = LanguageManager.Traducir("Lbl_Email");
            Lbl_NumeroEmpleado.Text = LanguageManager.Traducir("Lbl_NumeroEmpleado");
            Lbl_RolEmpleado.Text = LanguageManager.Traducir("Lbl_RolEmpleado");
            Lbl_Activo.Text = LanguageManager.Traducir("Lbl_Activo");

            // Botones
            Btn_GuardarEmpleado.Text = _idEditar == 0 ? LanguageManager.Traducir("Boton_Agregar") : LanguageManager.Traducir("Boton_Actualizar");
            Btn_Eliminar.Text = LanguageManager.Traducir("Boton_Eliminar");
            Btn_Agregar.Text = LanguageManager.Traducir("Boton_Agregar");
            Btn_Editar.Text = LanguageManager.Traducir("Boton_Editar");

            TraducirColumnasGrid();
        }

        private void TraducirColumnasGrid()
        {
            if (dataGridView1.Columns["Nombre"] != null)
                dataGridView1.Columns["Nombre"].HeaderText = LanguageManager.Traducir("Col_Nombre");

            if (dataGridView1.Columns["Apellido"] != null)
                dataGridView1.Columns["Apellido"].HeaderText = LanguageManager.Traducir("Col_Apellido");

            if (dataGridView1.Columns["Email"] != null)
                dataGridView1.Columns["Email"].HeaderText = LanguageManager.Traducir("Col_Email");

            if (dataGridView1.Columns["Contacto"] != null)
                dataGridView1.Columns["Contacto"].HeaderText = LanguageManager.Traducir("Col_Contacto");

            if (dataGridView1.Columns["Rol"] != null)
                dataGridView1.Columns["Rol"].HeaderText = LanguageManager.Traducir("Col_Rol");

            if (dataGridView1.Columns["DNI"] != null)
                dataGridView1.Columns["DNI"].HeaderText = LanguageManager.Traducir("Col_DNI");

            if (dataGridView1.Columns["UsuarioActivo"] != null)
                dataGridView1.Columns["UsuarioActivo"].HeaderText = LanguageManager.Traducir("Col_UsuarioActivo");
        }
        private void Switch_Activo_CheckedChanged(object sender, EventArgs e)
        {
            if (Switch_Activo.Checked)
            {
                Lbl_Activo.Text = LanguageManager.Traducir("Lbl_Activo");
            }
            else
            {
                Lbl_Activo.Text = LanguageManager.Traducir("Lbl_Inactivo");
            }
        }
        private void OcultarPanelEdicion()
        {
            Lbl_NombreEmpleado.Visible = false;
            Txt_NombreEmpleado.Visible = false;
            Lbl_ApellidoEmpleado.Visible = false;
            Txt_ApellidoEmpleado.Visible = false;
            Lbl_DniEmpleado.Visible = false;
            Txt_DniEmpleado.Visible = false;
            Lbl_Email.Visible = false;
            Txt_EmailEmpleado.Visible = false;
            Lbl_NumeroEmpleado.Visible = false;
            Txt_NumeroEmpleado.Visible = false;
            Lbl_RolEmpleado.Visible = false;
            Cbx_RolEmpleado.Visible = false;
            Lbl_Activo.Visible = false;
            Switch_Activo.Visible = false;
            Btn_GuardarEmpleado.Visible = false;
        }


        private void MostrarPanelEdicion()
        {
            Lbl_NombreEmpleado.Visible = true;
            Txt_NombreEmpleado.Visible = true;
            Lbl_ApellidoEmpleado.Visible = true;
            Txt_ApellidoEmpleado.Visible = true;
            Lbl_DniEmpleado.Visible = true;
            Txt_DniEmpleado.Visible = true;
            Lbl_Email.Visible = true;
            Txt_EmailEmpleado.Visible = true;
            Lbl_NumeroEmpleado.Visible = true;
            Txt_NumeroEmpleado.Visible = true;
            Lbl_RolEmpleado.Visible = true;
            Cbx_RolEmpleado.Visible = true;
            Lbl_Activo.Visible = true;
            Switch_Activo.Visible = true;
            Btn_GuardarEmpleado.Visible = true;
        }
    }
}
