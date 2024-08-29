namespace DotNet8.FluentEmail.WebApi.Extensions
{
    public static class DependencyInjection
    {
        public static void AddEmail(this IServiceCollection serices,
                        IConfigurationManager configuration)
        {
            var emailSettings = configuration.GetSection("EmailSettings");

            var defaultFromEmail = emailSettings["DefaultFromEmail"];
            var host = emailSettings["SMTPSetting:Host"];
            var port = emailSettings.GetValue<int>("Port");
            var userName = emailSettings["UserName"];
            var password = emailSettings["Password"];

            serices.AddFluentEmail(defaultFromEmail)
                   .AddSmtpSender(host, port, userName, password);
        }
    }
}
