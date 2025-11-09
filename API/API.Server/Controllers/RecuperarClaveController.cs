using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.Data.SqlClient;


namespace API.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecuperarClaveController : ControllerBase
    {
        [HttpPost]
        [Route("cambiarClave")]
        public IActionResult CambiarClave([FromBody] CambiarClaveRequest request)
        {
            string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TextControl;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT ID_Usuario FROM Usuario 
                                 WHERE UserName_Usuario = @username 
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
                                  SET Password_Usuario = @pass, RecoveryToken = NULL, RecoveryTokenExpiry = NULL
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