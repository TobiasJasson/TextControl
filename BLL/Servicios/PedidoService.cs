using DAL.Repository;
using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class PedidoService
    {
        private readonly PedidoRepository _repo;

        public PedidoService()
        {
            _repo = new PedidoRepository();
        }

        public List<PedidoDTO> ObtenerTodos()
        {
            return _repo.ObtenerTodos();
        }

        public List<PedidoDTO> ObtenerDetallesPorPedido(int idPedido)
        {
            if (idPedido <= 0)
                throw new ArgumentException("El ID del pedido debe ser mayor que cero.");

            return _repo.ObtenerDetallesPorPedido(idPedido);
        }
    }
}