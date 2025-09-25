using DomainModel;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SessionManager
    {
        private static SessionManager _instance;
        public Usuario UsuarioActual { get; private set; }
        public Empleados EmpleadoActual { get; private set; }

        private SessionManager() { }

        public static SessionManager Instance => _instance ??= new SessionManager();

        public void SetUsuario(Usuario usuario) => UsuarioActual = usuario;
        public void SetEmpeleado(Empleados empleado) => EmpleadoActual = empleado;
    }
}
