using DotNet8.FluentEmail.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DotNet8.FluentEmail.WebApi.Features.Email
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService) => _emailService = emailService;

        [HttpGet("singleEmail")]
        public async Task<IActionResult> SendSingleEmail(CancellationToken cancellationToken)
        {
            var emailMetaModel = new EmailMetaModel("b46on3367@gmail.com",
                "Hello Bro", "Who are you");
            await _emailService.Send(emailMetaModel, cancellationToken);
            return Ok("Send Successfully");
        }

        [HttpGet("withattachment")]
        public async Task<IActionResult> SendWithAttachment(CancellationToken cancellationToken)
        {
            EmailMetaModel emailModel = new("mglinnthithtoo@gmail.com"
                , "Fluent Test Email"
                , "This is the Test Email from Fluent Email",
                "C:\\HearnLeon\\asp.net.logo.png");
            await _emailService.SendWithAttachment(emailModel, cancellationToken);
            return Ok("Send Successfully");
        }

        [HttpGet("sendmultiple")]
        public async Task<IActionResult> SendMultipleEmail(CancellationToken cancellationToken)
        {
            List<UserModel> lstUser = new()
            {
                new("Hnin Ei Hlaing","hninei0056@gmail.com","VIP"),
                new("Min Khant Thu","b46on3367@gmail.com","VIP")
            };
            List<EmailMetaModel> lstEmail = new();
            foreach (var item in lstUser)
            {
                var emailModel = new EmailMetaModel(
                    item.Email!,
                    "Fluent Email Test",
                    "This is a test from minkhantthu-developer");
                lstEmail.Add(emailModel);
            }
            await _emailService.SendMultipleEmail(lstEmail,cancellationToken);
            return Ok("Send Successfully.");
        }
    }
}
