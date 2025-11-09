using DomainModel;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace BLL.Servicios
{
    public class EmailService
    {
        private readonly string fromEmail = ConfigurationManager.AppSettings["EmailSistema"];
        private readonly string fromPassword = ConfigurationManager.AppSettings["PasswordEmailSistema"];

        // URL base del servidor Railway (puede venir de variable de entorno o configuración)
        private readonly string baseUrl = Environment.GetEnvironmentVariable("RAILWAY_API_URL")
                                          ?? "https://textcontrol-production.up.railway.app";

        public void EnviarRecuperacionClave(Empleados empleado, string token, string nameUser)
        {
            var fromAddress = new MailAddress(fromEmail, "TextControl System");
            var toAddress = new MailAddress(empleado.Gmail, empleado.Nombre + " " + empleado.Apellido);

            string subject = "Recuperación de contraseña TextControl";
            string recoveryUrl = $"{baseUrl}/cambiarClave?usuario={nameUser}&token={token}";

            string body = $"Hola {empleado.Nombre} {empleado.Apellido},\n\n" +
                          "Si has solicitado recuperar tu clave en el sistema TextControl, " +
                          $"por favor haz clic en el siguiente enlace para restablecer tu contraseña:\n\n" +
                          $"{recoveryUrl}\n\n" +
                          "Si no lo has solicitado, por favor ignora este mensaje.";

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

            Console.WriteLine($"📧 Email de recuperación enviado a {empleado.Gmail} con link: {recoveryUrl}");
        }
    }
}