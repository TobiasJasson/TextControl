using Domain_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
                SELECT 
                    i.ID_Insumo, 
                    i.ID_TipoInsumo,
                    ti.Descripcion AS TipoInsumo,
                    i.Nombre,
                    c.ID_Color,
                    c.Descripcion_Color AS ColorDescripcion,
                    i.CantidadPorUnidad,
                    i.StockActual,
                    i.StockMinimo,
                    m.Cantidad AS CantidadMovimiento,
                    m.Fecha AS UltimaSalida,
                    tm.Descripcion AS TipoMovimiento,
                    i.PrecioUnitario
                FROM Insumo i
                LEFT JOIN Color c ON i.ID_Color = c.ID_Color
                LEFT JOIN (
                    SELECT 
                        ID_Insumo,
                        Cantidad,
                        Fecha,
                        ID_TipoMovimiento
                    FROM Movimiento_Stock
                    WHERE ID_TipoMovimiento = (
                        SELECT TOP 1 ID_TipoMovimiento 
                        FROM Tipo_Movimiento 
                        WHERE Descripcion = 'Salida'
                    )
                ) m ON i.ID_Insumo = m.ID_Insumo
                LEFT JOIN Tipo_Movimiento tm ON m.ID_TipoMovimiento = tm.ID_TipoMovimiento
                INNER JOIN Tipo_Insumo ti ON i.ID_TipoInsumo = ti.ID_TipoInsumo";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Insumo
                        {
                            ID_Insumo = dr.GetInt32(0),
                            ID_TipoInsumo = dr.GetInt32(1), // ahora corresponde al ID correcto
                            TipoInsumoDescripcion = dr.IsDBNull(2) ? null : dr.GetString(2),
                            Nombre = dr.IsDBNull(3) ? null : dr.GetString(3),
                            ID_Color = dr.IsDBNull(4) ? (int?)null : dr.GetInt32(4),
                            ColorNombre = dr.IsDBNull(5) ? null : dr.GetString(5),
                            CantidadPorUnidad = dr.IsDBNull(6) ? (double?)null : Convert.ToDouble(dr[6]),
                            StockActual = dr.GetInt32(7),
                            StockMinimo = dr.GetInt32(8),
                            CantidadMovimiento = dr.IsDBNull(9) ? 0 : dr.GetInt32(9),
                            UltimaSalida = dr.IsDBNull(10) ? (DateTime?)null : dr.GetDateTime(10),
                            TipoMovimiento = dr.IsDBNull(11) ? null : dr.GetString(11),
                            PrecioUnitario = dr.IsDBNull(12) ? 0 : Convert.ToDouble(dr[12])
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
                        ID_Color = @Color,
                        CantidadPorUnidad = @CantidadPorUnidad,
                        StockActual = @StockActual,
                        StockMinimo = @StockMinimo,
                        PrecioUnitario = @PrecioUnitario,
                        ID_TipoInsumo = (
                            SELECT TOP 1 ID_TipoInsumo 
                            FROM Tipo_Insumo 
                            WHERE Descripcion = @TipoInsumo
                        )
                    WHERE ID_Insumo = @ID_Insumo";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value =
                        string.IsNullOrWhiteSpace(insumo.Nombre) ? (object)DBNull.Value : insumo.Nombre;

                    cmd.Parameters.Add("@Color", SqlDbType.Int).Value =
                        insumo.ID_Color.HasValue ? (object)insumo.ID_Color.Value : DBNull.Value;

                    cmd.Parameters.Add("@CantidadPorUnidad", SqlDbType.Float).Value =
                        insumo.CantidadPorUnidad.HasValue ? (object)insumo.CantidadPorUnidad.Value : DBNull.Value;

                    cmd.Parameters.Add("@StockActual", SqlDbType.Int).Value = insumo.StockActual;
                    cmd.Parameters.Add("@StockMinimo", SqlDbType.Int).Value = insumo.StockMinimo;
                    cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Float).Value = insumo.PrecioUnitario;

                    cmd.Parameters.Add("@TipoInsumo", SqlDbType.VarChar, 50).Value =
                        string.IsNullOrWhiteSpace(insumo.TipoInsumoDescripcion) ? (object)DBNull.Value : insumo.TipoInsumoDescripcion;

                    cmd.Parameters.Add("@ID_Insumo", SqlDbType.Int).Value = insumo.ID_Insumo;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarInsumo(int idInsumo)
        {
            using (SqlConnection con = _conexion.GetConnection())
            {
                string queryMovimientos = "DELETE FROM Movimiento_Stock WHERE ID_Insumo = @ID_Insumo";
                using (SqlCommand cmdMov = new SqlCommand(queryMovimientos, con))
                {
                    cmdMov.Parameters.Add("@ID_Insumo", SqlDbType.Int).Value = idInsumo;
                    cmdMov.ExecuteNonQuery();
                }

                string queryInsumo = "DELETE FROM Insumo WHERE ID_Insumo = @ID_Insumo";
                using (SqlCommand cmdIns = new SqlCommand(queryInsumo, con))
                {
                    cmdIns.Parameters.Add("@ID_Insumo", SqlDbType.Int).Value = idInsumo;
                    cmdIns.ExecuteNonQuery();
                }
            }
        }

        public int CrearInsumo(InsumoInsert insumo)
        {
            using (var con = _conexion.GetConnection())
            {
                string query = @"
                    INSERT INTO Insumo
                    (ID_TipoInsumo, Nombre, ID_Color, CantidadPorUnidad, StockActual, StockMinimo, PrecioUnitario)
                    OUTPUT INSERTED.ID_Insumo
                    VALUES (@tipo, @nombre, @color, @cpu, @actual, @min, @precio)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@tipo", insumo.ID_TipoInsumo);
                cmd.Parameters.AddWithValue("@nombre", insumo.Nombre);
                cmd.Parameters.AddWithValue("@color", insumo.ID_Color.HasValue ? (object)insumo.ID_Color.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@cpu", insumo.CantidadPorUnidad);
                cmd.Parameters.AddWithValue("@actual", insumo.StockActual);
                cmd.Parameters.AddWithValue("@min", insumo.StockMinimo);
                cmd.Parameters.AddWithValue("@precio", insumo.PrecioUnitario);

                return (int)cmd.ExecuteScalar();
            }
        }

        public string ObtenerNombrePorIdSiEsTela(int idInsumo)
        {
            if (idInsumo <= 0) return null;

            try
            {
                using (var con = _conexion.GetConnection())
                {
                    string q = "SELECT Nombre FROM Insumo WHERE ID_Insumo = @id";
                    using (var cmd = new SqlCommand(q, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idInsumo);
                        var r = cmd.ExecuteScalar();
                        return r == null || r == DBNull.Value ? null : r.ToString();
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Talle> ObtenerTalles()
        {
            var lista = new List<Talle>();

            using (var con = _conexion.GetConnection())
            {
                string query = "SELECT ID_Talles, Detalles_Talles FROM Talles ORDER BY Detalles_Talles";
                using (var cmd = new SqlCommand(query, con))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Talle
                        {
                            ID_Talle = dr.GetInt32(0),
                            Detalle = dr.IsDBNull(1) ? null : dr.GetString(1)
                        });
                    }
                }
            }

            return lista;
        }

        public List<ColorModel> ObtenerColoresPorInsumo(int idInsumo)
        {
            var lista = new List<ColorModel>();

            using (var con = _conexion.GetConnection())
            {
                string query = @"
            SELECT c.ID_Color, c.Descripcion_Color
            FROM Insumo ic
            INNER JOIN Color c ON ic.ID_Color = c.ID_Color
            WHERE ic.ID_Insumo = @idInsumo";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idInsumo", idInsumo);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ColorModel
                            {
                                ID_Color = dr.GetInt32(0),
                                Descripcion = dr.GetString(1)
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public List<Insumo> ObtenerPorTipo(int idTipo)
        {
            var lista = new List<Insumo>();

            using (SqlConnection con = _conexion.GetConnection())
            {
                string query = @"
            SELECT ID_Insumo, Nombre 
            FROM Insumo 
            WHERE ID_TipoInsumo = @tipo
            ORDER BY Nombre";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@tipo", idTipo);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Insumo
                            {
                                ID_Insumo = dr.GetInt32(0),
                                Nombre = dr.GetString(1)
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}