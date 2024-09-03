namespace DotNet8.FluentEmail.WebApi.Models
{
    public class EmailMetaModel
    {
        public string? ToAddress { get; set; }

        public string? Subject { get; set; }

        public string? Body { get; set; }

        public string? AttachmentPath { get; set; }

        public EmailMetaModel(string toAddress,string subject
            ,string body="",string attachmentPath="")
        {
            ToAddress = toAddress;
            Subject = subject;
            Body = body;
            AttachmentPath = attachmentPath;
        }
    }
}
