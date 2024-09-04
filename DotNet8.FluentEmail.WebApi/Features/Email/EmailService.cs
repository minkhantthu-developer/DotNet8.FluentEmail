using DotNet8.FluentEmail.WebApi.Models;
using FluentEmail.Core;

namespace DotNet8.FluentEmail.WebApi.Features.Email
{
    public class EmailService : IEmailService
    {
        private readonly IFluentEmail _fluentEmail;
        private readonly IFluentEmailFactory _fluentEmailFactory;

        public EmailService(IFluentEmail fluentEmail,IFluentEmailFactory fluentEmailFactory)
        {
            _fluentEmail = fluentEmail;
            _fluentEmailFactory=fluentEmailFactory;
        }

        public async Task Send(EmailMetaModel emailMetaModel, CancellationToken cancellationToken)
        {
            await _fluentEmail.To(emailMetaModel.ToAddress)
                              .Subject(emailMetaModel.Subject)
                              .Body(emailMetaModel.Body)
                              .SendAsync(cancellationToken);
        }

        public async Task SendWithAttachment(EmailMetaModel emailMetaModel, CancellationToken cancellationToken)
        {
            await _fluentEmail.To(emailMetaModel.ToAddress)
                .Subject(emailMetaModel.Subject)
                .AttachFromFilename(emailMetaModel.AttachmentPath,
                  attachmentName: Path.GetFileName(emailMetaModel.AttachmentPath))
                .Body(emailMetaModel.Body)
                .SendAsync();
        }

        public async Task SendMultipleEmail(List<EmailMetaModel> lstEmail,
            CancellationToken cancellationToken)
        {
            foreach(var item in lstEmail)
            {
                await _fluentEmailFactory
                    .Create()
                    .To(item.ToAddress)
                    .Subject(item.Subject)
                    .Body(item.Body)
                    .SendAsync(cancellationToken);
            }
        }
    }
}
