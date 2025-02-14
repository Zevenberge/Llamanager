using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Llamanager.Engine;

public static class NdJsonExtensions
{
    public static async IAsyncEnumerable<T> ReadAsJsonEventStreamAsync<T>(this HttpContent content, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        using var stream = await content.ReadAsStreamAsync(cancellationToken);
        var reader = new StreamReader(stream);
        var line = await reader.ReadLineAsync(cancellationToken);
        while(!string.IsNullOrEmpty(line))
        {
            yield return JsonSerializer.Deserialize<T>(line)!;
            line = await reader.ReadLineAsync(cancellationToken);
        }
    }
}