using Llamanager.Tickets.SelfContained.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Llamanager.Tickets.SelfContained;

public static class ServiceCollectionExtensions
{
    public static void AddSelfContainedTicketing(this IServiceCollection services, Action<LlamaTicketConfiguation> configure)
    {
        services.Configure(configure);
        services.AddMvc().AddApplicationPart(typeof(ServiceCollectionExtensions).Assembly);
        services.AddScoped<LlamaTicketRepository>();
    }
}
