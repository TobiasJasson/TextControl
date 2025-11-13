using DAL.Repository;
using Domain_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class InsumoService
    {
        private readonly InsumoRepository _repo = new InsumoRepository();

        public List<Insumo> ObtenerStock() => _repo.ObtenerTodos();

        public List<Insumo> Buscar(string texto)
        {
            var lista = ObtenerStock();
            texto = texto?.ToLower() ?? "";

            return lista.FindAll(i =>
                i.Nombre.ToLower().Contains(texto) ||
                i.Color?.ToLower().Contains(texto) == true ||
                i.TipoInsumo.ToLower().Contains(texto));
        }

        public void Actualizar(Insumo insumo) => _repo.ActualizarInsumo(insumo);
    }
}
