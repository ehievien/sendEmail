using Microsoft.Extensions.Configuration;
using sendEmail.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sendEmail.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public EmailResponse SendMessage(EmailRequest request)
        {
            var apiKey = _config.GetSection("SENDGRID_API_KEY").Value;
            var client = new SendGridClient(apiKey);
            var from = request.Sender;
            List<EmailAddress> tos = request.Recipient;

            var subject = request.EmailSubject;
            var textContent = request.EmailBody;
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, textContent, "", false);
            var response = client.SendEmailAsync(msg);
            return new EmailResponse();
        }
    }
}
