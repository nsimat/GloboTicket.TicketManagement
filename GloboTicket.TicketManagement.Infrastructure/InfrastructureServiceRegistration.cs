using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Infrastructure.Mail;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.TicketManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
