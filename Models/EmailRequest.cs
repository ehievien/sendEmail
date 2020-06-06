using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace sendEmail
{
    public class EmailRequest
    {
        public EmailAddress Sender { get; set; }
        public List<EmailAddress> Recipient { get; set; }
        public EmailAddress BCC { get; set; }
        public string EmailBody { get; set; }
        public string EmailSubject { get; set; }
        //public byte[]  Attachment { get; set; }
    }
}

