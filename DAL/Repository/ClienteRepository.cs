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
    }
}