using GloboTicket.TicketManagement.Application.Profiles;
using GloboTicket.TicketManagement.Infrastructure;
using GloboTicket.TicketManagement.Persistence;

namespace GloboTicket.TicketManagement.Api
{
    public static class StartupExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddInfrastructureServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "MyBlazorPolicy",
                    policy =>
                    {
                        policy.WithOrigins("https://localhost:7278") // L'URL exacte du front-end (sans slash à la fin)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            return builder;
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options =>
                    options.SwaggerEndpoint("/openapi/v1.json", "v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("MyBlazorPolicy");
            app.MapControllers();

            return app;
        }
    }
}
