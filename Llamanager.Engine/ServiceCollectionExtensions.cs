using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Llamamanager.Engine;

public static class ServiceCollectionExtensions
{
    public static void AddLlm(this IServiceCollection services, Action<LlmSettings> configure)
    {
        services.Configure(configure);
        services.AddScoped<ILlmAgent, LlmAgent>();
        services.AddHttpClient(OllamaClient.HttpClient)
            .ConfigureHttpClient(static (svp, client) =>
            {
                var options = svp.GetRequiredService<IOptions<LlmSettings>>();
                client.BaseAddress = new Uri(options.Value.Url);
            });
    }
}