using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace DAL
{
    public class UsuarioRepository
    {
        private readonly Conexion _conexion;

        public UsuarioRepository()
        {
            _conexion = new Conexion();
        }
        public Usuario GetByUserAndPassword(string username, string passwordBase64)
        {
            using (var conn = _conexion.GetConnection())
            {
                conn.Open();
                var query = @"SELECT TOP 1 * 
                      FROM Usuario 
                      WHERE UserName_Usuario = @username 
                        AND Password_Usuario = @password";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", passwordBase64);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                IdUsuario = reader.GetInt32(reader.GetOrdinal("ID_Usuario")),
                                UserName = reader.GetString(reader.GetOrdinal("UserName_Usuario")),
                                Password = reader.GetString(reader.GetOrdinal("Password_Usuario")),
                                EmailRecuperacion = reader.GetString(reader.GetOrdinal("EmailRecuperacion_Usuario")),
                                IdEmpleado = reader.GetInt32(reader.GetOrdinal("ID_Empleado")),
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool ActualizarClave(string username, string nuevaClaveBase64)
        {
            using (var conn = _conexion.GetConnection())
            {
                conn.Open();

                var query = @"UPDATE Usuario 
                      SET Password_Usuario = @password 
                      WHERE UserName_Usuario = @username";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@password", nuevaClaveBase64);
                    cmd.Parameters.AddWithValue("@username", username);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        public Usuario GetByName(string userName)
        {
            using (var conn = _conexion.GetConnection())
            {
                conn.Open();
                var query = @"SELECT TOP 1 * FROM Usuario WHERE UserName_Usuario = @userName";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                UserName = reader.GetString(reader.GetOrdinal("UserName_Usuario")),
                                EmailRecuperacion = reader.GetString(reader.GetOrdinal("EmailRecuperacion_Usuario")),
                                IdEmpleado = reader.GetInt32(reader.GetOrdinal("ID_Empleado")),
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
