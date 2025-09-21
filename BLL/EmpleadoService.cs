using DAL;
using Domain_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmpleadoService
    {
        private readonly EmpleadoDAL _empleadoDAO = new EmpleadoDAL();

        public Empleado GetEmpleadoById(int id)
        {
            // Aquí podrías agregar validaciones si quieres
            return _empleadoDAO.GetById(id);
        }
    }
}
