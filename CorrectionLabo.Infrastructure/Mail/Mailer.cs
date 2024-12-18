using CorrectionLabo.Application.Abstractions.Mail;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace CorrectionLabo.Infrastructure.Mail
{
    public class Mailer(SmtpClient client, IConfiguration configuration):IMailer
    {
        public async Task<bool> SendAsync(string dest, string subject, string body)
        {
            MailMessage message = new MailMessage
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            message.To.Add(dest);
            message.From = new MailAddress(configuration["Smtp:AdminMail"] ?? throw new Exception("Missing configuration SMTP"));

            try {
                await Task.Run(() => { 
                    client.Send(message);
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
