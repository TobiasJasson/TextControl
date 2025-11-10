using DomainModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class EmailService
    {
        private readonly string fromEmail = ConfigurationManager.AppSettings["EmailSistema"];
        private readonly string fromPassword = ConfigurationManager.AppSettings["PasswordEmailSistema"];

        public void EnviarRecuperacionClave(Empleados empleado, string token, string nameUser)
        {
            var fromAddress = new MailAddress(fromEmail, "TextControl System");
            var toAddress = new MailAddress(empleado.Gmail, empleado.Nombre + " " + empleado.Apellido);

            string subject = "Recuperación de contraseña TextControl";
            string body = $"Hola {empleado.Nombre} {empleado.Apellido},\n\n" +
                          "Si has solicitado recuperar tu clave, hacé click en el siguiente enlace:\n" +
                          $"http://localhost:5500/cambiarClave?usuario={nameUser}&token={token}\n\n" +
                          "Este enlace expirará en 20 minutos.";

            // ✅ Guardamos token y hora en la DB
            string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SeguridadTexControl;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string update = @"UPDATE Usuario 
                          SET RecoveryToken = @token, RecoveryTokenExpiry = GETDATE()
                          WHERE UserName = @userName";

                using (SqlCommand cmd = new SqlCommand(update, conn))
                {
                    cmd.Parameters.AddWithValue("@token", token);
                    cmd.Parameters.AddWithValue("@userName", nameUser);
                    cmd.ExecuteNonQuery();
                }
            }

            // 📧 Enviar mail
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
