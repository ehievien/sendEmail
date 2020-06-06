using sendEmail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sendEmail.Services
{
    interface IEmailService
    {
        EmailResponse SendMessage(EmailRequest request);
    }
}
