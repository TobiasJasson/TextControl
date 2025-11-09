using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.Data.SqlClient;


namespace API.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecuperarClaveController : ControllerBase
    {
            [HttpGet]
            [Route("/cambiarClave")]
            public IActionResult CambiarClaveForm([FromQuery] string usuario, [FromQuery] string token)
            {
                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(token))
                    return BadRequest("Faltan parámetros.");

                string html = $@"
                <html>
                <head><title>Recuperar contraseña</title></head>
                <body style='font-family: Arial; text-align:center; margin-top:50px;'>
                    <h2>Restablecer contraseña de {usuario}</h2>
                    <form method='post' action='/api/RecuperarClave/cambiarClave'>
                        <input type='hidden' name='UserName' value='{usuario}' />
                        <input type='hidden' name='Token' value='{token}' />
                        <label>Nueva contraseña:</label><br/>
                        <input type='password' name='NuevaClave' required /><br/><br/>
                        <button type='submit'>Actualizar contraseña</button>
                    </form>
                </body>
                </html>";
                return Content(html, "text/html");
            }

            [HttpPost]
            [Route("cambiarClave")]
            public IActionResult CambiarClave([FromForm] CambiarClaveRequest request)
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
                        return BadRequest("Token inválido o expirado para este usuario.");

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

                return Content("<h3>✅ Clave actualizada correctamente.</h3>", "text/html");
            }

            public class CambiarClaveRequest
            {
                public required string UserName { get; set; }
                public required string Token { get; set; }
                public required string NuevaClave { get; set; }
            }
        }
    }