using SmartEdu.Models;

namespace SmartEdu.Services.EmailService
{
    public interface IEmailSenderService
    {       
        Task SendEmailAsync(EmailMessage message);
    }
}
