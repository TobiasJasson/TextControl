using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel
{
    public class PedidoDTO
    {
        public int ID_pedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime? FechaEntrega_pedido { get; set; }

        public double PrecioTotal_pedido { get; set; }
        public double SaldoPendiente_pedido { get; set; }
        public bool pagoAdelanto_pedido { get; set; }
        public double TotalPagosAdelantados { get; set; }

        // Cliente
        public int ID_Cliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Contacto_Cliente { get; set; }
        public string Email_Cliente { get; set; }

        // Empleado
        public int? ID_Empleado { get; set; }
        public string Nombre_Empleado { get; set; }
        public string Apellido_Empleado { get; set; }
        public string Contacto_Empleado { get; set; }

        // Estado y prioridad
        public string Prioridad { get; set; }
        public string EstadoPedido { get; set; }

        // Detalle
        public int ID_Detalle { get; set; }
        public int ID_Tela { get; set; }
        public string Color_Detalle { get; set; }
        public int ID_Talle { get; set; }
        public string Detalles_Talles { get; set; }
        public int Cantidad_Detalle { get; set; }
        public double Precio_Detalle { get; set; }

        // Personalización
        public string Personalizacion_Tipo { get; set; }
        public string Personalizacion_Diseno { get; set; }
        public string Personalizacion_Tamano { get; set; }
        public string Personalizacion_Posicion { get; set; }
        public double Personalizacion_Precio { get; set; }
    }
}