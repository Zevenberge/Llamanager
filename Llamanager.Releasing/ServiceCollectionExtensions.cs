using Llamanager.Releasing.Controllers;
using Llamanager.Releasing.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Llamanager.Tickets.SelfContained;

public static class ServiceCollectionExtensions
{
    public static void AddSelfContainedTicketing(this IServiceCollection services)
    {
        services.AddMvc()
            .AddApplicationPart(typeof(ReleaseRequestController).Assembly)
            .AddControllersAsServices();
        services.AddScoped<IReleaseRequestRepository, ReleaseRequestRepository>();
    }
}
