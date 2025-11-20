using Domain_Model;
using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class PedidoRepository
    {
        private readonly ConexionTextControl _conexion;

        public PedidoRepository()
        {
            _conexion = new ConexionTextControl();
        }

        public List<PedidoDTO> ObtenerTodos()
        {
            var lista = new List<PedidoDTO>();

            using (SqlConnection con = _conexion.GetConnection())
            {
                string query = "SELECT * FROM view_PedidosCompleto";
                SqlCommand cmd = new SqlCommand(query, con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var dto = MapearPedido(dr);
                        lista.Add(dto);
                    }
                }
            }

            return lista;
        }
        public List<PedidoDTO> ObtenerDetallesPorPedido(int idPedido)
        {
            var lista = new List<PedidoDTO>();

            try
            {
                using (SqlConnection con = _conexion.GetConnection())
                {
                    string query = "SELECT * FROM view_PedidosCompleto WHERE ID_pedido = @ID_pedido";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ID_pedido", idPedido);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var dto = MapearPedido(dr);
                            lista.Add(dto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener detalles del pedido {idPedido}: {ex.Message}", ex);
            }

            return lista;
        }

        private PedidoDTO MapearPedido(SqlDataReader dr)
        {
            return new PedidoDTO
            {
                ID_pedido = dr.GetInt32(dr.GetOrdinal("ID_pedido")),
                FechaPedido = dr.GetDateTime(dr.GetOrdinal("FechaPedido")),
                FechaEntrega_pedido = dr.IsDBNull(dr.GetOrdinal("FechaEntrega_pedido"))
                    ? (DateTime?)null
                    : dr.GetDateTime(dr.GetOrdinal("FechaEntrega_pedido")),

                PrecioTotal_pedido = Convert.ToDouble(dr["PrecioTotal_pedido"]),
                SaldoPendiente_pedido = Convert.ToDouble(dr["SaldoPendiente_pedido"]),
                pagoAdelanto_pedido = Convert.ToBoolean(dr["pagoAdelanto_pedido"]),
                TotalPagosAdelantados = Convert.ToDouble(dr["TotalPagosAdelantados"]),

                ID_Cliente = Convert.ToInt32(dr["ID_Cliente"]),
                Nombre_Cliente = dr["Nombre_Cliente"].ToString(),
                Contacto_Cliente = dr["Contacto_Cliente"].ToString(),
                Email_Cliente = dr["Email_Cliente"].ToString(),

                ID_Empleado = dr["ID_Empleado"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["ID_Empleado"]),
                Nombre_Empleado = dr["Nombre_Empleado"]?.ToString(),
                Apellido_Empleado = dr["Apellido_Empleado"]?.ToString(),
                Contacto_Empleado = dr["Contacto_Empleado"]?.ToString(),

                Prioridad = dr["Prioridad"].ToString(),
                EstadoPedido = dr["Descripcion_EstadoPedido"].ToString(),

                ID_Detalle = Convert.ToInt32(dr["ID_Detalle"]),
                ID_Tela = Convert.ToInt32(dr["ID_Tela"]),
                Color_Detalle = dr["Color_Detalle"].ToString(),
                ID_Talle = Convert.ToInt32(dr["ID_Talle"]),
                Detalles_Talles = dr["Detalles_Talles"].ToString(),
                Cantidad_Detalle = Convert.ToInt32(dr["Cantidad_Detalle"]),
                Precio_Detalle = Convert.ToDouble(dr["Precio_Detalle"]),

                Personalizacion_Tipo = dr["Personalizacion_Tipo"]?.ToString(),
                Personalizacion_Diseno = dr["Personalizacion_Diseno"]?.ToString(),
                Personalizacion_Tamano = dr["Personalizacion_Tamano"]?.ToString(),
                Personalizacion_Posicion = dr["Personalizacion_Posicion"]?.ToString(),
                Personalizacion_Precio = dr["Personalizacion_Precio"] == DBNull.Value
                    ? 0
                    : Convert.ToDouble(dr["Personalizacion_Precio"])
            };
        }

        public void GuardarPedido(Pedido pedido, List<DetallePedido> detalles, float adelanto)
        {
            using (var con = _conexion.GetConnection())
            using (var tran = con.BeginTransaction())
            {
                try
                {
                    // Insert Pedido
                    string insertPedido = @"
                INSERT INTO Pedidos
                (FechaPedido, FechaEntrega_pedido, PrecioTotal_pedido, SaldoPendiente_pedido, 
                 pagoAdelanto_pedido, ID_Cliente, ID_Empleado, ID_EstadoPedido, ID_Prioridad)
                OUTPUT INSERTED.ID_pedido
                VALUES
                (@fechaPedido, @fechaEntrega, @precioTotal, @saldoPendiente, 
                 @pagoAdelantado, @idCliente, @idEmpleado, @idEstado, @idPrioridad)";

                    SqlCommand cmdPedido = new SqlCommand(insertPedido, con, tran);
                    cmdPedido.Parameters.AddWithValue("@fechaPedido", pedido.FechaPedido);
                    cmdPedido.Parameters.AddWithValue("@fechaEntrega", pedido.FechaEtrega);
                    cmdPedido.Parameters.AddWithValue("@precioTotal", pedido.PrecioTotal);
                    cmdPedido.Parameters.AddWithValue("@saldoPendiente", pedido.SaldoPendiente);
                    cmdPedido.Parameters.AddWithValue("@pagoAdelantado", pedido.PagoAdelantado);
                    cmdPedido.Parameters.AddWithValue("@idCliente", pedido.IdCliente);
                    cmdPedido.Parameters.AddWithValue("@idEmpleado", pedido.IdEmpleado);
                    cmdPedido.Parameters.AddWithValue("@idEstado", 1);
                    cmdPedido.Parameters.AddWithValue("@idPrioridad", 2);

                    int idPedido = (int)cmdPedido.ExecuteScalar();

                    // Insert detalles
                    foreach (var det in detalles)
                    {
                        string insertDetalle = @"
                    INSERT INTO Detalle_Pedido
                    (ID_Pedido, ID_Tela, Color_Detalle, ID_Talle, Cantidad_Detalle, PrecioUnitario)
                    VALUES
                    (@idPedido, @idTela, @color, @idTalle, @cantidad, @precio)";

                        SqlCommand cmdDetalle = new SqlCommand(insertDetalle, con, tran);
                        cmdDetalle.Parameters.AddWithValue("@idPedido", idPedido);
                        cmdDetalle.Parameters.AddWithValue("@idTela", det.IdTela);
                        cmdDetalle.Parameters.AddWithValue("@color", det.Color_Detalle ?? "");
                        cmdDetalle.Parameters.AddWithValue("@idTalle", det.IdTalle);
                        cmdDetalle.Parameters.AddWithValue("@cantidad", det.Cantidad_Detalle);
                        cmdDetalle.Parameters.AddWithValue("@precio", det.PrecioUnitario);
                        cmdDetalle.ExecuteNonQuery();

                        // Insert movimiento stock
                        string insertMov = @"
                    INSERT INTO Movimiento_Stock
                    (ID_TipoMovimiento, ID_Insumo, Cantidad, Fecha, ID_Pedido)
                    VALUES
                    (2, @idInsumo, @cantidad, GETDATE(), @idPedido)";

                        SqlCommand cmdMov = new SqlCommand(insertMov, con, tran);
                        cmdMov.Parameters.AddWithValue("@idInsumo", det.IdTela);
                        cmdMov.Parameters.AddWithValue("@cantidad", det.Cantidad_Detalle);
                        cmdMov.Parameters.AddWithValue("@idPedido", idPedido);
                        cmdMov.ExecuteNonQuery();
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }
    }
}