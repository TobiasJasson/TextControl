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
        private readonly Conexion _conexion = new Conexion();

        public Empleados GetById(int id)
        {
            using (var conn = _conexion.GetConnection())
            {
                conn.Open();
                var query = "SELECT TOP 1 * FROM Empleado WHERE Id_empleado = @id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Empleados
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
    }
}
