using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Model
{
    public class Insumo
    {
        public int IdInsumo { get; set; }
        public int IdTipoInsumo { get; set; }
        public string DescripcionInsumo { get; set; }
        public string ColorInsumo { get; set; }
        public string DiseñoInsumo { get; set; }
        public int CantidadPorUnidad { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
    }
}
