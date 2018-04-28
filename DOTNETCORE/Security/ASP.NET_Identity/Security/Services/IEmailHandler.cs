using MimeKit.Text;

namespace Security.Services
{
    public interface IEmailHandler
    {
        void SendMessage(EmailMessage message, TextFormat format = TextFormat.Plain);
        void SendEmailConfirmation(string email, string link);
        void SendResetPasswordEmail(string email, string link);
    }
}