using sendEmail.Models;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sendEmail.Services
{
   public interface IEmailService
    {
       Task<Response> SendMessage(EmailRequest request);
    }
}
