using DAL;
using DomainModel;
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

        public Empleados GetEmpleadoById(int id)
        {
            // Aquí podrías agregar validaciones si quieres
            return _empleadoDAO.GetById(id);
        }
    }
}
