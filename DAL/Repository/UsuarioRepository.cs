using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DomainModel;

namespace DAL.Repository
{
    public class UsuarioRepositorySeguridad : IUsuarioRepository
    {
        private readonly ConexionLogin _conexion;

        public UsuarioRepositorySeguridad()
        {
            _conexion = new ConexionLogin();
        }

        public Usuario GetByUserAndPassword(string username, string passwordBase64)
        {
            using (var conn = _conexion.GetConnection())
            {
                conn.Open();
                var query = @"SELECT TOP 1 * 
                              FROM Usuario 
                              WHERE UserName = @username 
                              AND PasswordHash = @password 
                              AND Activo = 1";

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
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                Password = reader.GetString(reader.GetOrdinal("PasswordHash")),
                                EmailRecuperacion = reader.GetString(reader.GetOrdinal("Email")),
                                IdEmpleado = reader.IsDBNull(reader.GetOrdinal("ID_Empleado")) ? 0 : reader.GetInt32(reader.GetOrdinal("ID_Empleado")),
                                Activo = reader.GetBoolean(reader.GetOrdinal("Activo")),
                            };
                        }
                    }
                }
            }
            return null;
        }

        public Usuario GetByName(string userName)
        {
            using (var conn = _conexion.GetConnection())
            {
                conn.Open();
                var query = @"SELECT TOP 1 * FROM Usuario WHERE UserName = @userName";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                IdUsuario = reader.GetInt32(reader.GetOrdinal("ID_Usuario")),
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                EmailRecuperacion = reader.GetString(reader.GetOrdinal("Email")),
                                IdEmpleado = reader.IsDBNull(reader.GetOrdinal("ID_Empleado")) ? 0 : reader.GetInt32(reader.GetOrdinal("ID_Empleado")),
                                Activo = reader.GetBoolean(reader.GetOrdinal("Activo"))
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
                              SET PasswordHash = @password 
                              WHERE UserName = @username";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@password", nuevaClaveBase64);
                    cmd.Parameters.AddWithValue("@username", username);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public Usuario GetByUserNameAndToken(string username, string token)
        {
            using (var conn = _conexion.GetConnection())
            {
                conn.Open();
                var query = @"
            SELECT TOP 1 *
            FROM Usuario
            WHERE UserName = @username
              AND RecoveryToken = @token
              AND Activo = 1";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@token", token);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                IdUsuario = reader.GetInt32(reader.GetOrdinal("ID_Usuario")),
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                EmailRecuperacion = reader.GetString(reader.GetOrdinal("Email")),
                                Password = reader.GetString(reader.GetOrdinal("PasswordHash")),
                                IdEmpleado = reader.IsDBNull(reader.GetOrdinal("ID_Empleado")) ? 0 : reader.GetInt32(reader.GetOrdinal("ID_Empleado")),
                                Activo = reader.GetBoolean(reader.GetOrdinal("Activo")),
                                RecoveryToken = reader.IsDBNull(reader.GetOrdinal("RecoveryToken")) ? null : reader.GetString(reader.GetOrdinal("RecoveryToken")),
                                RecoveryTokenExpiry = reader.IsDBNull(reader.GetOrdinal("RecoveryTokenExpiry")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("RecoveryTokenExpiry"))
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void InvalidateRecoveryToken(string username)
        {
            using (var conn = _conexion.GetConnection())
            {
                conn.Open();
                var query = @"UPDATE Usuario 
                      SET RecoveryToken = NULL, RecoveryTokenExpiry = NULL 
                      WHERE UserName = @username";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SaveRecoveryToken(string username, string token, DateTime expiry)
        {
            using (var conn = _conexion.GetConnection())
            {
                conn.Open();
                var query = @"UPDATE Usuario 
                              SET RecoveryToken = @token, RecoveryTokenExpiry = @expiry 
                              WHERE UserName = @username";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@token", token);
                    cmd.Parameters.AddWithValue("@expiry", expiry);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}