using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Logging
{
    public class BitacoraDAO
    {
        private readonly ConexionTextControl _conexion = new ConexionTextControl();
        public void Registrar(BitacoraEntry entry)
        {
            using (var conn = _conexion.GetConnection())
            {
                conn.Open();

                var cmd = new SqlCommand(@"
                    INSERT INTO Bitacora
                    (FechaHora, IdUsuario, UserName, Accion, Entidad, EntidadId, Descripcion)
                    VALUES (GETDATE(), @IdUsuario, @UserName, @Accion, @Entidad, @EntidadId, @Descripcion)",
                conn);

                cmd.Parameters.AddWithValue("@IdUsuario", (object)entry.IdUsuario ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UserName", (object)entry.UserName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Accion", entry.Accion);
                cmd.Parameters.AddWithValue("@Entidad", entry.Entidad);
                cmd.Parameters.AddWithValue("@EntidadId", (object)entry.EntidadId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Descripcion", (object)entry.Descripcion ?? DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }
    }
}