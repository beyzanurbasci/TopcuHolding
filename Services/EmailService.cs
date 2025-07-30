using MailKit.Net.Smtp;
using MimeKit;

namespace TopcuHolding.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Web İletişim", _config["SmtpSettings:User"]));
            email.To.Add(MailboxAddress.Parse(_config["SmtpSettings:To"]));
            email.Subject = subject;
            email.Body = new TextPart("plain") { Text = body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_config["SmtpSettings:Host"], int.Parse(_config["SmtpSettings:Port"]), false);
            await smtp.AuthenticateAsync(_config["SmtpSettings:User"], _config["SmtpSettings:Pass"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
