using System.Net;
using System.Net.Mail;

namespace SharedData.EmailSender.Implementations
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var smtpClient = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential
                {
                    UserName = "sisbrinfo@gmail.com",
                    Password = "dalqisdlanvvkkcn"
                }
            };

            var fromEmail = new MailAddress("sisbrinfo@gmail.com", "SISBR");
            var toEmail = new MailAddress(email, "SISBR");

            var emailMessage = new MailMessage
            {
                From = fromEmail,
                Subject = subject,
                Body = message
            };

            emailMessage.To.Add(toEmail);

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(1000);
                    smtpClient.Send(emailMessage);
                }

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
