using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmpleadoDAL
    {
        private readonly ConexionTextControl _conexion = new ConexionTextControl();

        public Empleado GetById(int id)
        {
            using (var conn = _conexion.GetConnection())
            {
                //conn.Open();
                var query = "SELECT TOP 1 * FROM Empleado WHERE Id_empleado = @id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Empleado
                            {
                                IdEmpleado = (int)reader["ID_Empleado"],
                                Nombre = reader["Nombre_Empleado"].ToString(),
                                Apellido = reader["Apellido_Empleado"].ToString(),
                                Gmail = reader["Gmail_Empleado"].ToString(),
                                DNI = reader["DNI_Empleado"].ToString(),
                                Contacto = reader["Contacto_Empleado"].ToString(),
                                IdRol = (int)reader["ID_Rol"],
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public bool ActualizarGmail(int idEmpleado, string nuevoGmail)
        {
            using (var conn = _conexion.GetConnection())
            {
                conn.Open();

                var query = @"UPDATE Empleado 
                      SET Gmail_Empleado = @nuevoGmail 
                      WHERE ID_Empleado = @idEmpleado";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nuevoGmail", nuevoGmail);
                    cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
