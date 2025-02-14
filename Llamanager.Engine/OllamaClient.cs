using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Options;

namespace Llamamanager.Engine;

public class OllamaClient(IHttpClientFactory httpClientFactory, IOptions<LlmSettings> options)
{
    public const string HttpClient = nameof(OllamaClient);
    public async IAsyncEnumerable<string> GetResponse(string prompt, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var request = new OllamaCompletionRequest(options.Value.Model, prompt, true);
        using var client = httpClientFactory.CreateClient(HttpClient);
        var response = await client.PostAsJsonAsync("/api/generate", request, cancellationToken);
        await foreach(var token in response.Content.ReadAsJsonEventStreamAsync<OllamaCompletionResponse>(cancellationToken))
        {
            yield return token.Response;
        }
    }
}
