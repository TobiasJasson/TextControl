using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Model
{
    public class Insumo
    {
        public int ID_Insumo { get; set; }
        public string TipoInsumo { get; set; }
        public string Nombre { get; set; }
        public int? ID_Color { get; set; }
        public string ColorNombre { get; set; }
        public double? CantidadPorUnidad { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int CantidadMovimiento { get; set; }
        public DateTime? UltimaSalida { get; set; }
        public string TipoMovimiento { get; set; }
        public double PrecioUnitario { get; set; }
    }

    public class InsumoInsert
    {
        public int ID_TipoInsumo { get; set; }
        public string Nombre { get; set; }
        public int? ID_Color { get; set; }
        //public string Diseno { get; set; }
        public double CantidadPorUnidad { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}