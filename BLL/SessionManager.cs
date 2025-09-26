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

        // Implementación correcta del Singleton
        public static SessionManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SessionManager();
                return _instance;
            }
        }

        public void SetUsuario(Usuario usuario) => UsuarioActual = usuario;

        // Corrige el typo: SetEmpleado en lugar de SetEmpeleado
        public void SetEmpleado(Empleados empleado) => EmpleadoActual = empleado;
    }
}