using Domain_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class TipoInsumoRepository
    {
        private readonly ConexionTextControl _conexion;
        public TipoInsumoRepository()
        {
            _conexion = new ConexionTextControl();
        }

        public List<TipoInsumo> ObtenerTodos()
        {
            var lista = new List<TipoInsumo>();

            using (var con = _conexion.GetConnection())
            {
                string query = "SELECT ID_TipoInsumo, Descripcion FROM Tipo_Insumo ORDER BY Descripcion";

                using (var cmd = new SqlCommand(query, con))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new TipoInsumo
                        {
                            ID_TipoInsumo = dr.GetInt32(0),
                            Descripcion = dr.GetString(1)
                        });
                    }
                }
            }

            return lista;
        }

        public TipoInsumo ObtenerPorDescripcion(string descripcion)
        {
            using (var con = _conexion.GetConnection())
            {
                string query = "SELECT ID_TipoInsumo, Descripcion FROM Tipo_Insumo WHERE Descripcion = @desc";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@desc", descripcion);

                //con.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new TipoInsumo
                        {
                            ID_TipoInsumo = dr.GetInt32(0),
                            Descripcion = dr.GetString(1)
                        };
                    }
                }
            }
            return null;
        }

        public int CrearTipoInsumo(string descripcion)
        {
            using (var con = _conexion.GetConnection())
            {
                string query = "INSERT INTO Tipo_Insumo (Descripcion) OUTPUT INSERTED.ID_TipoInsumo VALUES (@desc)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@desc", descripcion);

                //con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public List<string> BuscarCoincidencias(string texto)
        {
            var lista = new List<string>();

            using (var con = _conexion.GetConnection())
            {
                string query = "SELECT Descripcion FROM Tipo_Insumo WHERE Descripcion LIKE @txt";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@txt", SqlDbType.VarChar, 100).Value = texto + "%";

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(dr.GetString(0));
                        }
                    }
                }
            }
            return lista;
        }
    }
}