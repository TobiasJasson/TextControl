using DomainModel;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
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

        public void EnviarBienvenida(Empleado empleado, string userName, int idEmpleado, string token)
        {
            string subject = "Bienvenido a TextControl";
            string body = $"Usted ha sido incluido en el equipo de TextControl.\n" +
                          $"Use el siguiente link para crear su clave:\n" +
                          $"http://localhost:5500/cambiarClave?id={idEmpleado}&token={token}\n\n" +
                          $"Su usuario será: {userName}";

            GuardarToken(userName, token);

            EnviarCorreo(empleado.Gmail, empleado.Nombre, empleado.Apellido, subject, body);
        }

        public void EnviarRecuperacionClave(Empleado empleado, string token, string userName)
        {
            string subject = "Recuperación de contraseña TextControl";
            string body = $"Hola {empleado.Nombre} {empleado.Apellido},\n\n" +
                          "Si has solicitado recuperar tu clave, haz click en el siguiente enlace:\n" +
                          $"http://localhost:5500/cambiarClave?usuario={userName}&token={token}\n\n" +
                          "Este enlace expirará en 20 minutos.";

            GuardarToken(userName, token);

            EnviarCorreo(empleado.Gmail, empleado.Nombre, empleado.Apellido, subject, body);
        }

        private void EnviarCorreo(string emailDestino, string nombre, string apellido, string subject, string body)
        {
            var fromAddress = new MailAddress(fromEmail, "TextControl System");
            var toAddress = new MailAddress(emailDestino, $"{nombre} {apellido}");

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

        private void GuardarToken(string userName, string token)
        {
            string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SeguridadTexControl;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string update = @"UPDATE Usuario 
                                  SET RecoveryToken = @token, RecoveryTokenExpiry = DATEADD(MINUTE, 20, GETDATE())
                                  WHERE UserName = @userName";

                using (SqlCommand cmd = new SqlCommand(update, conn))
                {
                    cmd.Parameters.AddWithValue("@token", token);
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
