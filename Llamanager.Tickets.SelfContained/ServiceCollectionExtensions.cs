using Llamanager.Tickets.SelfContained.Controllers;
using Llamanager.Tickets.SelfContained.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Llamanager.Tickets.SelfContained;

public static class ServiceCollectionExtensions
{
    public static void AddSelfContainedTicketing(this IServiceCollection services, Action<LlamaTicketConfiguation> configure)
    {
        services.Configure(configure);
        services.AddMvc()
            .AddApplicationPart(typeof(LlamaTicketController).Assembly)
            .AddControllersAsServices();
        services.AddScoped<ILlamaTicketRepository, LlamaTicketRepository>();
    }
}
