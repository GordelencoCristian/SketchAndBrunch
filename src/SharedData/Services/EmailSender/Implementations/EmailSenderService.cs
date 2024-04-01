using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using SharedData.Configurations;

namespace SharedData.Services.EmailSender.Implementations
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly EmailSenderConfig _config;

        public EmailSenderService(IOptions<EmailSenderConfig> config)
        {
            _config = config.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var smtpClient = new SmtpClient()
            {
                Host = _config.Server,
                Port = _config.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential
                {
                    UserName = _config.UserName,
                    Password = _config.Password,
                }
            };

            var fromEmail = new MailAddress("sisbrinfo@gmail.com", "Sketch & Brunch");
            var toEmail = new MailAddress(email, "Sketch & Brunch");

            var emailMessage = new MailMessage
            {
                From = fromEmail,
                Subject = subject,
                Body = message
            };

            emailMessage.To.Add(toEmail);

            try
            {
                smtpClient.Send(emailMessage);

                Console.WriteLine("Email sent successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            await Task.CompletedTask;
        }
    }
}
