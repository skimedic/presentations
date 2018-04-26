using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace Security.Services
{
    //http://www.mimekit.net/docs/html/Getting-Started.htm
    public class EmailHandlerMailKit : IEmailHandler
    {
        private readonly EmailSettings _emailSettings;

        public EmailHandlerMailKit(IOptionsSnapshot<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public void SendMessage(EmailMessage emailMessage, TextFormat format = TextFormat.Plain)
        {
            var message = new MimeMessage();
            var toAddresses = emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Email));
            message.To.AddRange(toAddresses);
            message.Bcc.AddRange(emailMessage.BccAddresses.Select(x => new MailboxAddress(x, x)));
            message.From.Add(new MailboxAddress(emailMessage.Sender, emailMessage.FromEmailAddress));
            message.Subject = emailMessage.Subject;
            //We will say we are sending HTML. But there are options for plaintext etc. 
            message.Body = new TextPart(format)
            {
                Text = emailMessage.Body
            };
            using (var emailClient = new SmtpClient())
            {
                try
                {
                    emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    emailClient.Connect(_emailSettings.SmtpHost, _emailSettings.SmtpPort, _emailSettings.UseSsl);
                    emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                    emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.EmailPassword);
                    emailClient.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }

                emailClient.Disconnect(true);
            }
        }

        public void SendEmailConfirmation(string email, string link)
        {
            EmailMessage emailMessage = new EmailMessage
            {
                Subject = "Confirm your email",
                Body =
                    $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>",
                FromEmailAddress = "admin@dayofagile.org"
            };
            emailMessage.ToAddresses.Add((email, email));
            SendMessage(emailMessage, TextFormat.Html);
        }

        public void SendResetPasswordEmail(string email, string link)
        {
            EmailMessage emailMessage = new EmailMessage
            {
                Subject = "Reset Password",
                Body = $"Please reset your password by clicking here: <a href='{link}'>link</a>",
                FromEmailAddress = "admin@dayofagile.org"
            };
            emailMessage.ToAddresses.Add((email, email));
            SendMessage(emailMessage, TextFormat.Html);
        }
    }
}