using CorrectionLabo.Application.Abstractions.Mail;
using CorrectionLabo.Application.Abstractions.Repositories;
using CorrectionLabo.Application.Abstractions.Services;
using CorrectionLabo.Application.Services;
using CorrectionLabo.Infrastructure.Database.Repositories;
using CorrectionLabo.Infrastructure.Mail;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace CorrectionLabo.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMemberRepository, MemberRepository>();
            return services;
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IMemberService, MemberService>();
            return services;
        }
        public static IServiceCollection AddMailer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(s => new SmtpClient()
            {
                Timeout = 5000,
                EnableSsl = true,
                Host = configuration["Smtp:Host"] ?? throw new Exception(),
                Port = int.Parse(configuration["Smtp:Port"] ?? throw new Exception()),
                Credentials = new NetworkCredential
                {
                    UserName = configuration["Smtp:Username"] ?? throw new Exception(),
                    Password = configuration["Smtp:Password"] ?? throw new Exception(),
                }
            });
            services.AddScoped<IMailer, Mailer>();

            return services;
        }
    }
}
