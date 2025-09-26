using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Model
{
    public class PagoAdelantado
    {
        public int IdPagoAdelantado { get; set; }
        public float MontoAdelantado { get; set; }
        public DateTime FechaPagoAdelantado { get; set; }
        public int IdPedido { get; set; }
    }
}
