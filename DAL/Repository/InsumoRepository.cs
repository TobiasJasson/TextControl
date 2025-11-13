using Domain_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class InsumoRepository
    {
        private readonly ConexionTextControl _conexion;

        public InsumoRepository()
        {
            _conexion = new ConexionTextControl();
        }

        public List<Insumo> ObtenerTodos()
        {
            var lista = new List<Insumo>();

            using (SqlConnection con = _conexion.GetConnection())
            {
                string query = @"
                    SELECT i.ID_Insumo, ti.Descripcion AS TipoInsumo, i.Nombre, i.Color, i.Diseno, 
                           i.CantidadPorUnidad, i.StockActual, i.StockMinimo, 
                           m.Cantidad AS CantidadMovimiento, m.Fecha, tm.Descripcion AS TipoMovimiento
                    FROM Insumo i
                    INNER JOIN Movimiento_Stock m ON i.ID_Insumo = m.ID_Insumo
                    INNER JOIN Tipo_Movimiento tm ON m.ID_TipoMovimiento = tm.ID_TipoMovimiento
                    INNER JOIN Tipo_Insumo ti ON i.ID_TipoInsumo = ti.ID_TipoInsumo
                    WHERE tm.Descripcion = 'Salida'";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Insumo
                        {
                            ID_Insumo = dr.GetInt32(0),
                            TipoInsumo = dr.IsDBNull(1) ? null : dr.GetString(1),
                            Nombre = dr.IsDBNull(2) ? null : dr.GetString(2),
                            Color = dr.IsDBNull(3) ? null : dr.GetString(3),
                            Diseno = dr.IsDBNull(4) ? null : dr.GetString(4),
                            CantidadPorUnidad = dr.IsDBNull(5) ? (double?)null : Convert.ToDouble(dr[5]),
                            StockActual = dr.GetInt32(6),
                            StockMinimo = dr.GetInt32(7),
                            CantidadMovimiento = dr.GetInt32(8),
                            UltimaSalida = dr.IsDBNull(9) ? (DateTime?)null : dr.GetDateTime(9),
                            TipoMovimiento = dr.IsDBNull(10) ? null : dr.GetString(10),
                            PrecioUnitario = CalcularPrecioEstimado(dr.IsDBNull(2) ? null : dr.GetString(2))
                        });
                    }
                }
            }

            return lista
                .GroupBy(i => i.ID_Insumo)
                .Select(g => g.OrderByDescending(i => i.UltimaSalida).First())
                .ToList();
        }

        public void ActualizarInsumo(Insumo insumo)
        {
            using (SqlConnection con = _conexion.GetConnection())
            {
                string query = @"
                    UPDATE Insumo SET 
                        Nombre = @Nombre,
                        Color = @Color,
                        Diseno = @Diseno,
                        CantidadPorUnidad = @CantidadPorUnidad,
                        StockActual = @StockActual,
                        StockMinimo = @StockMinimo,
                        ID_TipoInsumo = (
                            SELECT TOP 1 ID_TipoInsumo 
                            FROM Tipo_Insumo 
                            WHERE Descripcion = @TipoInsumo
                        )
                    WHERE ID_Insumo = @ID_Insumo";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", insumo.Nombre ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Color", insumo.Color ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Diseno", insumo.Diseno ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CantidadPorUnidad", insumo.CantidadPorUnidad ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@StockActual", insumo.StockActual);
                    cmd.Parameters.AddWithValue("@StockMinimo", insumo.StockMinimo);
                    cmd.Parameters.AddWithValue("@TipoInsumo", insumo.TipoInsumo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ID_Insumo", insumo.ID_Insumo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private double CalcularPrecioEstimado(string nombre)
        {
            if (string.IsNullOrEmpty(nombre)) return 0;
            string lower = nombre.ToLower();

            if (lower.Contains("hilo")) return 250;
            if (lower.Contains("botón")) return 500;
            if (lower.Contains("tela")) return 1500;
            if (lower.Contains("cuero")) return 2500;
            return 100;
        }
    }
}