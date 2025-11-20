using Domain_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ClienteRepository
    {
        private readonly ConexionTextControl _conexion = new ConexionTextControl();

        public List<Cliente> ObtenerTodos()
        {
            var lista = new List<Cliente>();

            using (var con = _conexion.GetConnection())
            {
                string query = "SELECT ID_Cliente, Nombre_Cliente, Contacto_Cliente, Email_Cliente FROM Cliente";
                using (var cmd = new SqlCommand(query, con))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Cliente
                        {
                            ID_Cliente = dr.GetInt32(0),
                            Nombre_Cliente = dr.GetString(1),
                            Contacto_Cliente = dr.IsDBNull(2) ? null : dr.GetString(2),
                            Email_Cliente = dr.IsDBNull(3) ? null : dr.GetString(3)
                        });
                    }
                }
            }

            return lista;
        }
        public void Insertar(Cliente c)
        {
            using (var con = _conexion.GetConnection())
            {
                string query = @"INSERT INTO Cliente (Nombre_Cliente, Contacto_Cliente, Email_Cliente)
                                 VALUES (@nombre, @contacto, @email)";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", c.Nombre_Cliente);
                    cmd.Parameters.AddWithValue("@contacto", c.Contacto_Cliente ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", c.Email_Cliente ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Actualizar(Cliente c)
        {
            using (var con = _conexion.GetConnection())
            {
                string query = @"UPDATE Cliente
                                 SET Nombre_Cliente=@nombre,
                                     Contacto_Cliente=@contacto,
                                     Email_Cliente=@email
                                 WHERE ID_Cliente=@id";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", c.ID_Cliente);
                    cmd.Parameters.AddWithValue("@nombre", c.Nombre_Cliente);
                    cmd.Parameters.AddWithValue("@contacto", c.Contacto_Cliente ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", c.Email_Cliente ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int idCliente)
        {
            using (var con = _conexion.GetConnection())
            {
                string query = "DELETE FROM Cliente WHERE ID_Cliente=@id";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", idCliente);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}