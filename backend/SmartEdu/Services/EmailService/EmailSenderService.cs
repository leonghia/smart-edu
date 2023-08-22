using MailKit.Net.Smtp;
using MimeKit;
using SmartEdu.Models;
using Serilog;

namespace SmartEdu.Services.EmailService
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly EmailOptions _emailConfig;
        public EmailSenderService(EmailOptions emailConfig)
        {
            _emailConfig = emailConfig;
        }
        

        public async Task SendEmailAsync(EmailMessage message)
        {
            var emailMessage = CreateEmailMessage(message);
            await SendAsync(emailMessage);
        }

        private async Task SendAsync(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.Username, _emailConfig.Password);

                    await client.SendAsync(emailMessage);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Something went wrong in the {nameof(SendAsync)} method");
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }        

        private MimeMessage CreateEmailMessage(EmailMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Product Nest", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };

            return emailMessage;
        }     
    }
}
