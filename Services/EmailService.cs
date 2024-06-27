using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Reciclagem.api.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public EmailService(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _smtpUsername = smtpUsername;
            _smtpPassword = smtpPassword;
        }

        public void EnviarEmail(string destinatario, string assunto, string mensagem)
        {
            using (var client = new SmtpClient(_smtpServer, _smtpPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                client.EnableSsl = true;

                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_smtpUsername);
                mailMessage.To.Add(destinatario);
                mailMessage.Subject = assunto;
                mailMessage.Body = mensagem;

                client.Send(mailMessage);
            }
        }
    }
}
