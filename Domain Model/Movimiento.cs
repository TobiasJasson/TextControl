using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Model
{
    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public int IdTipoMovimiento { get; set; }
        public int IdInsumo { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha_Movimiento { get; set; }
        public int IdPedido { get; set; }

    }
}
