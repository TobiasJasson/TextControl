using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailRecuperacion { get; set; }
        public int IdEmpleado { get; set; }
        public bool Activo { get; set; }
        public string RecoveryToken { get; set; }
        public DateTime? RecoveryTokenExpiry { get; set; }
    }
}
