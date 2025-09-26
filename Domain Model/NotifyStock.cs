using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Model
{
    public class NotifyStock
    {
        public int IdNotificacion { get; set; }
        public int IdPrioridad { get; set; }
        public DateTime FechaNotify { get; set; }
        public int IdInsumo { get; set; }
    }
}
