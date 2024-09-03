namespace DotNet8.FluentEmail.WebApi.Extensions
{
    public static class DependencyInjection
    {
        public static void AddEmail(this IServiceCollection serices,
                        IConfigurationManager configuration)
        {
            var fromEmail = configuration.GetSection("FluentEmail:FromEmail")?.Value;

            serices.AddFluentEmail(fromEmail)
                   .AddSmtpSender("smtp.gmail.com", 587, fromEmail, "tjqc zvli bkqd hzjt");
        }
    }
}
