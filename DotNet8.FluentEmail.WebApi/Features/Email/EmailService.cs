using DotNet8.FluentEmail.WebApi.Models;
using FluentEmail.Core;

namespace DotNet8.FluentEmail.WebApi.Features.Email
{
    public class EmailService : IEmailService
    {
        private readonly IFluentEmail _fluentEmail;

        public EmailService(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task Send(EmailMetaModel emailMetaModel, CancellationToken cancellationToken)
        {
            await _fluentEmail.To(emailMetaModel.ToAddress)
                              .Subject(emailMetaModel.Subject)
                              .Body(emailMetaModel.Body)
                              .SendAsync(cancellationToken);
        }
    }
}
