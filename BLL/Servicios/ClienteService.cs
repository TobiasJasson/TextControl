using DAL.Repository;
using Domain_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class ClienteService
    {
        private readonly ClienteRepository _repo = new ClienteRepository();

        public List<Cliente> GetAll() => _repo.ObtenerTodos();
    }
}
