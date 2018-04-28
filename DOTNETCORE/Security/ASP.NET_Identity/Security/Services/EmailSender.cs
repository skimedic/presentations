using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace Security.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private readonly IEmailHandler _emailHandler;

        public EmailSender(IEmailHandler emailHandler)
        {
            _emailHandler = emailHandler;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            EmailMessage emailMessage = new EmailMessage
            {
                Subject = "Confirm your email",
                Body = message,                
                FromEmailAddress = "admin@dayofagile.org"
            };
            emailMessage.ToAddresses.Add((email, email));

            _emailHandler.SendMessage(emailMessage, TextFormat.Html);
            return Task.CompletedTask;
        }
    }
}
