using Domain_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ColorRepository
    {
        private readonly ConexionTextControl _conexion;

        public ColorRepository()
        {
            _conexion = new ConexionTextControl();
        }

        public List<ColorModel> ObtenerTodos()
        {
            var lista = new List<ColorModel>();

            using (var con = _conexion.GetConnection())
            {
                string query = "SELECT ID_Color, Descripcion_Color FROM Color ORDER BY Descripcion_Color";

                using (var cmd = new SqlCommand(query, con))
                {
                    //con.Open()
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

        public int ObtenerOCrear(string descripcion)
        {
            using (var con = _conexion.GetConnection())
            {
                //con.Open();

                // Ver si existe
                string existeQuery = "SELECT ID_Color FROM Color WHERE Descripcion = @desc";
                using (var cmd = new SqlCommand(existeQuery, con))
                {
                    cmd.Parameters.AddWithValue("@desc", descripcion);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        return (int)result;
                }

                // Crear
                string insertQuery = "INSERT INTO Color (Descripcion) OUTPUT INSERTED.ID_Color VALUES (@desc)";
                using (var cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@desc", descripcion);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}