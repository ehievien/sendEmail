using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using sendEmail.Services;

namespace sendEmail.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private ILogger<SendEmailController> _logger;
        private IEmailService _emailservice;
        public SendEmailController(ILogger<SendEmailController> logger, IEmailService emailservice)
        {
            _logger = logger;
            _emailservice = emailservice;
        }


        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation($"Found a unicorn on SendEmail Controller");
            return Ok();
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult SendEmail([FromBody] EmailRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values);
                }
            
                _logger.LogInformation($"about to send email --{request.EmailSubject}");
                var response = _emailservice.SendMessage(request);
                if(response.Id > 0)
                    return StatusCode(StatusCodes.Status200OK);
                else return StatusCode(StatusCodes.Status406NotAcceptable);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"exception ---" + ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
