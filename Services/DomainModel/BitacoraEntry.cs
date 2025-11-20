using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel
{
    public class BitacoraEntry
    {
        public int ID_Bitacora { get; set; }
        public DateTime FechaHora { get; set; }
        public int? IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Accion { get; set; }
        public string Entidad { get; set; }
        public string EntidadId { get; set; }
        public string Descripcion { get; set; }
    }
}
