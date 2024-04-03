using MediatR.Pipeline;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedData.Configurations;
using SharedData.Services.EmailSender;
using SharedData.Services.EmailSender.Implementations;
using System.Reflection;
using FluentValidation;

namespace SharedData.Infrastructure
{
    public static class ServiceConfiguration
    {
        public static void ConfigureEmailSender(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.AddOptions();
            services.Configure<EmailSenderConfig>(configurationSection);
            services.AddTransient<IEmailSenderService, EmailSenderService>();
        }

        public static void ConfigureModuleApplication(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestAuthorizationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
