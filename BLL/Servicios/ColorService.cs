using DAL.Repository;
using Domain_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class ColorService
    {
        private readonly ColorRepository _repo = new ColorRepository();

        public List<ColorModel> ObtenerTodosLosColores()
        {
            return _repo.ObtenerTodos();
        }

        public int ObtenerOCrear(string descripcion)
        {
            return _repo.ObtenerOCrear(descripcion);
        }
    }
}