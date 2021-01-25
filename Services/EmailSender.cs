using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HLAN.Services
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html);
    }

    public class EmailSender : IEmailService
    {
        private IConfiguration Configuration { get; set; }
        public EmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Send(string to, string subject, string html)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("HLAN@savezaustralskognogometa.com"));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            var SmtpHost = Configuration.GetValue<string>("SMPT:Host");
            var SmtpPort = Configuration.GetValue<int>("SMPT:Port");
            var SmtpPass = Configuration.GetValue<string>("SMPT:Pass");
            var SmtpUser = Configuration.GetValue<string>("SMPT:User");
            using var smtp = new SmtpClient();
            smtp.Connect(SmtpHost, SmtpPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(SmtpUser, SmtpPass);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
