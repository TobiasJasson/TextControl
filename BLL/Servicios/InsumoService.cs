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

        public List<Talle> GetAllTalles()
        {
            return _repo.ObtenerTalles();
        }

        public List<Insumo> ObtenerPorTipo(int tipoId)
        {
            return _repo.ObtenerPorTipo(tipoId);
        }

        public List<ColorModel> ObtenerColoresPorInsumo(int idInsumo)
        {
            return _repo.ObtenerColoresPorInsumo(idInsumo);
        }


        public double GetPrecio(int idInsumo)
        {
            var insumo = _repo.ObtenerTodos().FirstOrDefault(i => i.ID_Insumo == idInsumo);
            return insumo?.PrecioUnitario ?? 0;
        }


        public int CrearInsumo(InsumoInsert insumo)
        {
            return _repo.CrearInsumo(insumo);
        }

        public List<Insumo> GetAll()
        {
            return ObtenerStock();
        }

        public List<Insumo> Buscar(string texto)
        {
            var lista = ObtenerStock();
            texto = texto?.ToLower() ?? "";

            return lista.FindAll(i =>
                (i.Nombre?.ToLower().Contains(texto) ?? false) ||
                (i.ColorNombre?.ToLower().Contains(texto) ?? false) ||
                (i.TipoInsumoDescripcion?.ToLower().Contains(texto) ?? false)
            );
        }

        public void Actualizar(Insumo insumo) => _repo.ActualizarInsumo(insumo);

        public void Eliminar(int idInsumo) => _repo.EliminarInsumo(idInsumo);
    }
}
