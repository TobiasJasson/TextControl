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

        public Empleado GetEmpleadoById(int id)
        {
            return _empleadoDAO.GetById(id);
        }

        public bool CambiarGmail(int idEmpleado, string nuevoGmail)
        {
            return _empleadoDAO.ActualizarGmail(idEmpleado, nuevoGmail);
        }
    }
}
