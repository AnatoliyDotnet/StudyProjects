using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Login
{
    public static class EmailSender
    {
        public static void SendCredentials(User user)
        {
            var subject = "LMS Credentials";
            var body = $"<h3>Login: {user.Login}</h3><h3>Password: {user.Password}</h3>";
            SendEmail(subject, body, user);
        }

        private static void SendEmail(string subject, string body, User user)
        {
            var fromAddress = new MailAddress("mail.helpproject@gmail.com", "LMS");
            var toAddress = new MailAddress(user.Email, user.FirstName);
            const string fromPassword = "HelpProject2017";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            try
            {
                smtp.Send(message);
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}
