using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Model
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEtrega { get; set; }
        public int IdDetalle { get; set; }
        public float PrecioTotal { get; set; }
        public float SaldoPendiente { get; set; }
        public bool PagoAdelantado { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public int IdPrioridad { get; set; }
    }

    public class DetallePedido
    {
        public int IdDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdTela { get; set; }
        public string Color_Detalle { get; set; }
        public string Talle_Detalle { get; set; }
        public int Cantidad_Detalle { get; set; }
        public float PrecioUnitario { get; set; }
    }
}
