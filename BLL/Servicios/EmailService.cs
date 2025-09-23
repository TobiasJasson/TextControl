using Domain_Model;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        public void EnviarRecuperacionClave(Empleado empleado, string token, string nameUser)
        {
            var fromAddress = new MailAddress(fromEmail, "TextControl System");
            var toAddress = new MailAddress(empleado.Gmail, empleado.Nombre + " " + empleado.Apellido);

            string subject = "Recuperación de contraseña TextControl";
            string body = $"Hola {empleado.Nombre} {empleado.Apellido},\n\n" +
                          "Si has seleccionado la opción recuperar la clave en el sistema TextControl, " +
                          $"por favor realiza click en el siguiente link para ingresar tu nueva clave:\n" +
                          $"http://localhost:5500/cambiarClave?usuario={nameUser}&token={token}\n\n" +
                          "Si no lo has solicitado, por favor ignore este mensaje.";

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
