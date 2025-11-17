using DAL.Repository;
using Domain_Model;
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
        private readonly PedidoRepository _repo = new PedidoRepository();

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

        public void GuardarPedido(Pedido pedido, List<DetallePedido> detalles, float adelanto)
        {
            int totalPrendas = detalles.Sum(d => d.Cantidad_Detalle);
            int diasExtra = totalPrendas / 5;
            pedido.FechaEtrega = DateTime.Now.AddDays(60 + diasExtra);

            _repo.GuardarPedido(pedido, detalles, adelanto);
        }
    }
}