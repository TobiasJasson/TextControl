using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.Data.SqlClient;


namespace API.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecuperarClaveController : ControllerBase
    {
        // ✅ Corrige el nombre de la base de datos
        private readonly string connectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SeguridadTexControl;Integrated Security=True;Trust Server Certificate=True";

        [HttpPost("cambiarClave")]
        public IActionResult CambiarClave([FromBody] CambiarClaveRequest request)
        {
            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Token))
                return BadRequest("Datos incompletos.");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // ✅ Verifica token y que no haya expirado (20 min)
                string checkQuery = @"
                    SELECT ID_Usuario 
                    FROM Usuario 
                    WHERE UserName = @username 
                      AND RecoveryToken = @token 
                      AND DATEADD(MINUTE, 20, RecoveryTokenExpiry) > GETDATE()";

                int? userId = null;

                using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@username", request.UserName);
                    cmd.Parameters.AddWithValue("@token", request.Token);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        userId = Convert.ToInt32(result);
                }

                if (userId == null)
                    return BadRequest("El token es inválido o ha expirado.");

                // ✅ Encripta nueva contraseña (Base64)
                string passBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(request.NuevaClave));

                // ✅ Actualiza la clave y limpia el token
                string updateQuery = @"
                    UPDATE Usuario 
                    SET PasswordHash = @pass, 
                        RecoveryToken = NULL, 
                        RecoveryTokenExpiry = NULL
                    WHERE ID_Usuario = @id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@pass", passBase64);
                    cmd.Parameters.AddWithValue("@id", userId.Value);
                    cmd.ExecuteNonQuery();
                }
            }

            return Ok(new { message = "Contraseña actualizada correctamente." });
        }

        public class CambiarClaveRequest
        {
            public required string UserName { get; set; }
            public required string Token { get; set; }
            public required string NuevaClave { get; set; }
        }
    }
}