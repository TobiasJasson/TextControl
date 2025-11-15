using BLL.Interfaces;
using BLL.Servicios;
using DomainModel;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UI.FormsComun.Admin
{
    public partial class FormControlEmpleado : Form
    {
        private UsuarioService _servicio;
        private int _idEditar = 0;
        public FormControlEmpleado()
        {
            InitializeComponent();
        }

        private void FormControlEmpleado_Load(object sender, EventArgs e)
        {
            _servicio = new UsuarioService();
            OcultarPanelEdicion();
            CargarGrid();
        }

        private void CargarGrid()
        {
            dataGridView1.DataSource = _servicio.ObtenerGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            MostrarPanelEdicion();
            Btn_GuardarEmpleado.Text = "Guardar";
        }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            MostrarPanelEdicion();
            Btn_GuardarEmpleado.Text = "Actualizar";

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            _idEditar = Convert.ToInt32(row.Cells["ID_Usuario"].Value);

            Txt_NombreEmpleado.Text = row.Cells["NombreEmpleado"].Value.ToString();
            Txt_ApellidoEmpleado.Text = row.Cells["ApellidoEmpleado"].Value.ToString();
            Txt_EmailEmpleado.Text = row.Cells["Email"].Value.ToString();
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

        private void Lbl_Empleado_Click(object sender, EventArgs e)
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

        private async void Btn_GuardarEmpleado_Click(object sender, EventArgs e)
        {
            UsuarioService usuarioService = new UsuarioService();

            var emp = new Empleado
            {
                Nombre = Txt_NombreEmpleado.Text,
                Apellido = Txt_ApellidoEmpleado.Text,
                DNI = Txt_DniEmpleado.Text,
                Contacto = Txt_NumeroEmpleado.Text,
                Gmail = Txt_EmailEmpleado.Text
            };

            string userName = emp.Nombre; // lo que pediste
            string passHash = Convert.ToBase64String(Encoding.UTF8.GetBytes("claveTemporal"));

            var usu = new Usuario
            {
                UserName = userName,
                Password = passHash,
                EmailRecuperacion = emp.Gmail,
                Activo = Switch_Activo.Checked
            };
            var token = UsuarioService.GenerateToken();
            var expiry = DateTime.Now.AddMinutes(30);
            usuarioService.SaveRecoveryToken(userName, token, expiry);

            int rol = (Cbx_RolEmpleado.SelectedIndex == 0) ? 1 : 2;

            int idCreado = _servicio.CrearEmpleado(emp, usu, rol);
            var emailService = new EmailService();
            await Task.Run(() => emailService.EnviarBienvenida(emp, userName, idCreado, token));

            MessageBox.Show("Empleado creado correctamente");

            OcultarPanelEdicion();
            CargarGrid();
        }

        private void Switch_Activo_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void OcultarPanelEdicion()
        {
            Lbl_NombreEmpleado.Visible = false;
            Txt_NombreEmpleado.Visible = false;
            Lbl_ApellidoEmpleado.Visible = false;
            Txt_ApellidoEmpleado.Visible = false;
            Lbl_DniEmpleado.Visible = false;
            Txt_DniEmpleado.Visible = false;
            Lbl_Empleado.Visible = false;
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
            Lbl_Empleado.Visible = true;
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
