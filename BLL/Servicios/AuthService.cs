using DomainModel;
using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class AuthService
    {
        private readonly UsuarioService _usuarioService;

        public AuthService()
        {
            _usuarioService = new UsuarioService();
        }

        public Usuario UsuarioActual { get; set; }

        public Empleado EmpleadoActual { get; set; }

        public Rol RolActual { get; set; }

        public string SessionToken { get; set; }

        public bool Login(string username, string password)
        {
            var usuario = _usuarioService.Login(username, password);
            if (usuario == null) return false;

            UsuarioActual = usuario;

            EmpleadoActual = ObtenerEmpleado(usuario.IdEmpleado);

            RolActual = ObtenerRol(EmpleadoActual?.IdRol ?? 0);

            SessionToken = Guid.NewGuid().ToString();

            return true;
        }

        public void Logout()
        {
            UsuarioActual = null;
            EmpleadoActual = null;
            RolActual = null;
            SessionToken = null;
        }

        public void Refresh()
        {
            if (UsuarioActual == null) return;

            UsuarioActual = _usuarioService.RecuperarClave(UsuarioActual.UserName); // o un método GetById
            EmpleadoActual = ObtenerEmpleado(UsuarioActual.IdEmpleado);
            RolActual = ObtenerRol(EmpleadoActual?.IdRol ?? 0);
        }

        public bool CambiarClave(string nuevaClave)
        {
            if (UsuarioActual == null) return false;
            bool result = _usuarioService.CambiarClave(UsuarioActual.UserName, nuevaClave);
            if (result) Refresh();
            return result;
        }

        private Empleado ObtenerEmpleado(int idEmpleado)
        {
            var dt = _usuarioService.ObtenerGrid();
            var row = dt.AsEnumerable().FirstOrDefault(r => r.Field<int>("ID_Empleado") == idEmpleado);
            if (row == null) return null;

            return new Empleado
            {
                IdEmpleado = idEmpleado,
                Nombre = row.Field<string>("Nombre"),
                Apellido = row.Field<string>("Apellido"),
                DNI = row.Field<string>("DNI"),
                Gmail = row.Field<string>("Email"),
                Contacto = row.Field<string>("NumeroContacto"),
                IdRol = row.Field<int>("ID_Rol")
            };
        }

        private Rol ObtenerRol(int idRol)
        {
            return new Rol
            {
                IdRol = idRol,
                DescipcionRol = "Rol_" + idRol
            };
        }
    }
}