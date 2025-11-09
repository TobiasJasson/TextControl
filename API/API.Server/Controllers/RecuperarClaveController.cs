using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.Data.SqlClient;


namespace API.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecuperarClaveController : ControllerBase
    {
        // ✅ Redirige al frontend Node (API.Client) cuando el usuario abre el link del mail
        [HttpGet("/cambiarClave")]
        public IActionResult RedirigirFormulario([FromQuery] string usuario, [FromQuery] string token)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(token))
                return BadRequest("Faltan parámetros.");

            // URL del servicio CLIENT (Node.js en Railway)
            string frontendUrl = Environment.GetEnvironmentVariable("RAILWAY_CLIENT_URL")
                ?? "https://textcontrol-client-production.up.railway.app";

            string redirectUrl = $"{frontendUrl}/cambiarClave?usuario={usuario}&token={token}";
            return Redirect(redirectUrl);
        }

        [HttpPost("cambiarClave")]
        public IActionResult CambiarClave([FromBody] CambiarClaveRequest request)
        {
            string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING_SEGURIDAD")
                ?? @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SeguridadTexControl;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT ID_Usuario FROM Usuario 
                                 WHERE UserName = @username 
                                   AND RecoveryToken = @token 
                                   AND RecoveryTokenExpiry > GETDATE()";

                int? userId = null;
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", request.UserName);
                    cmd.Parameters.AddWithValue("@token", request.Token);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        userId = Convert.ToInt32(result);
                }

                if (userId == null)
                    return BadRequest(new { message = "Token inválido o expirado para este usuario." });

                string passBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(request.NuevaClave));

                string update = @"UPDATE Usuario 
                                  SET PasswordHash = @pass, RecoveryToken = NULL, RecoveryTokenExpiry = NULL
                                  WHERE ID_Usuario = @id";

                using (SqlCommand cmd = new SqlCommand(update, conn))
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