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
      
        public async Task<Response> SendMessage(EmailRequest request)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = request.Sender;
            List<EmailAddress> tos = request.Recipient;

            var subject = request.EmailSubject;
            var textContent = request.EmailBody;
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, textContent, "", false);
            var response = await client.SendEmailAsync(msg);
            return response;
        }
    }
}
