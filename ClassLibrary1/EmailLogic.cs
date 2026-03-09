using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
namespace TrackerLibrary
{
    public static class EmailLogic
    {
        private static readonly IConfiguration _config;
        private static readonly EmailSettings _settings;

        static EmailLogic()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("EmailConfig.json", optional: false, reloadOnChange: true)
                .Build();

            _settings = _config.GetSection("EmailSettings").Get<EmailSettings>();
        }
        public static void SendEmail(string to, string subject, string body)
        {

            MailAddress fromMailAddress = new MailAddress(_settings.FromEmail, _settings.FromDisplayName);

            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = fromMailAddress;
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            using SmtpClient client = new SmtpClient(_settings.Host, _settings.Port)
            {
                Credentials = new NetworkCredential(_settings.UserName, _settings.Password),
                EnableSsl = _settings.EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            client.Send(mail);
        }
    }
}
