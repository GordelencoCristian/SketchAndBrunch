using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedData.Configurations;
using SharedData.Services.EmailSender;
using SharedData.Services.EmailSender.Implementations;

namespace SharedData.Services
{
    public static class ServiceConfiguration
    {
        public static void ConfigureEmailSender(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.AddOptions();
            services.Configure<EmailSenderConfig>(configurationSection);
            services.AddTransient<IEmailSenderService, EmailSenderService>();
        }
    }
}
