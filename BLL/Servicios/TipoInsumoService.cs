using DAL.Repository;
using Domain_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class TipoInsumoService
    {
        private readonly TipoInsumoRepository _repo = new TipoInsumoRepository();

        public int ObtenerOCrear(string descripcion)
        {
            var existe = _repo.ObtenerPorDescripcion(descripcion);

            if (existe != null)
                return existe.ID_TipoInsumo;

            return _repo.CrearTipoInsumo(descripcion);
        }

        public List<TipoInsumo> ObtenerTodos()
        {
            return _repo.ObtenerTodos();
        }

        public List<string> BuscarCoincidencias(string texto)
        {
            if (texto.Length < 2)
                return new List<string>();

            return _repo.BuscarCoincidencias(texto);
        }
    }
}
