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
    
    [Route("[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private ILogger<SendEmailController> _logger;
        private EmailService _emailservice;
        private readonly IConfiguration _config;
        public SendEmailController(ILogger<SendEmailController> logger, IConfiguration config)
        {
            _config = config;
            _logger = logger;
            _emailservice = new EmailService(config);
        }


        [HttpGet]
        public IActionResult Get()
        {
            //Log the unicorn!
            _logger.LogInformation($"Found a unicorn on Haul Cycle Controller");

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
                    return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"exception ---" + ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
