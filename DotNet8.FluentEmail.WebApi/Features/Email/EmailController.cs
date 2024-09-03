﻿using DotNet8.FluentEmail.WebApi.Models;
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
            await _emailService.Send(emailMetaModel,cancellationToken);
            return Ok();
        }

        [HttpGet("withattachment")]
        public async Task<IActionResult> SendWithAttachment(CancellationToken cancellationToken)
        {
            EmailMetaModel emailModel = new("b46on3367@gmail.com"
                , "Fluent Test Email"
                , "This is the Test Email from Fluent Email",
                "C:\\Baby lay\\ဘေဘီလေးနှင်းအိလှိုင်Part1.txt");
            await _emailService.SendWithAttachment(emailModel,cancellationToken);
            return Ok();
        }
    }
}
