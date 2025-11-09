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

        private readonly string baseUrl = Environment.GetEnvironmentVariable("RAILWAY_API_URL")
                                          ?? "https://textcontrol.up.railway.app";

        /// <summary>
        /// Envía un correo electrónico de recuperación de contraseña.
        /// </summary>
        public void EnviarRecuperacionClave(Empleados empleado, string token, string nameUser)
        {
            try
            {
                if (empleado == null || string.IsNullOrEmpty(empleado.Gmail))
                    throw new ArgumentException("El empleado no tiene un correo válido.");

                var fromAddress = new MailAddress(fromEmail, "TextControl System");
                var toAddress = new MailAddress(empleado.Gmail, $"{empleado.Nombre} {empleado.Apellido}");

                string recoveryUrl = $"{baseUrl}/cambiarClave?usuario={Uri.EscapeDataString(nameUser)}&token={Uri.EscapeDataString(token)}";

                string subject = "Recuperación de contraseña - TextControl";
                string body =
                    $@"Hola {empleado.Nombre} {empleado.Apellido},
                    Has solicitado restablecer tu contraseña en el sistema TextControl.
                    Por favor, haz clic en el siguiente enlace para establecer una nueva clave:
                    {recoveryUrl}
                    
                    Si tú no realizaste esta solicitud, simplemente ignora este mensaje.
                    
                    Saludos,
                    Equipo de TextControl";

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

                Console.WriteLine($"✅ Email de recuperación enviado correctamente a {empleado.Gmail}");
                Console.WriteLine($"🔗 Enlace generado: {recoveryUrl}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al enviar el correo de recuperación: {ex.Message}");
                throw;
            }
        }
    }
}