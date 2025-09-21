using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Model
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Gmail { get; set; }
        public string Contacto { get; set; }

        // Relación con Usuario
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
