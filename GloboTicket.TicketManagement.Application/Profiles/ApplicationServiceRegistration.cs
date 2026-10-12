using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.TicketManagement.Application.Profiles
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var licenseKey = configuration["LuckyPenny:LicenseKey"];

            services.AddAutoMapper(cfg =>
            {
                // Register mapping profiles
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());

                // Configure the free license key
                cfg.LicenseKey = licenseKey;
                //_=> { }, AppDomain.CurrentDomain.GetAssemblies()
            });

            services.AddMediatR(cfg =>
                {
                    // Register handlers
                    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

                    // Configure the free license key
                    cfg.LicenseKey = licenseKey;
                });

            return services;
        }
    }
}
