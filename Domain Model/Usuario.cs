using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Usuario
    {
        public int IdUsuario { get; set; }          
        public string UserName { get; set; }            
        public string Password { get; set; }           
        public string EmailRecuperacion { get; set; }  
        public int IdEmpleado { get; set; }

        // Navegación opcional
        public List<Empleados> Empleados { get; set; } = new List<Empleados>();
    }
}
