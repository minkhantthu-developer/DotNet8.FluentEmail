using DotNet8.FluentEmail.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.FluentEmail.WebApi.Features.Email
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService) => _emailService = emailService;

        [HttpPost("singleEmail")]
        public async Task<IActionResult> SendSingleEmail(CancellationToken cancellationToken)
        {
            var emailMetaModel = new EmailMetaModel("b46on3367@gmail.com",
                "Hello Bro", "Who are you");
            await _emailService.Send(emailMetaModel,cancellationToken);
            return Ok();
        }
    }
}
