using DotNet8.FluentEmail.WebApi.Models;

namespace DotNet8.FluentEmail.WebApi.Features.Email
{
    public interface IEmailService
    {
        Task Send(EmailMetaModel emailMetaModel,
            CancellationToken cancellationToken);

        Task SendWithAttachment(EmailMetaModel emailMetaModel,
            CancellationToken cancellationToken);

        Task SendMultipleEmail(List<EmailMetaModel> lstEmail,
            CancellationToken cancellationToken);
    }
}
