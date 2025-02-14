using Microsoft.Extensions.Primitives;

namespace Llamanager.Web;

public class ServerSentEventStream(HttpResponse httpResponse)
{
    public const string CookieName = "sse-session-id";
    public string SessionId { get; } = Guid.NewGuid().ToString();

    public async Task Open()
    {
        httpResponse.StatusCode = StatusCodes.Status200OK;
        httpResponse.ContentType = "text/event-stream";
        httpResponse.Headers.CacheControl = new StringValues("no-cache");
        httpResponse.Headers.Connection = new StringValues("keep-alive");
        httpResponse.Cookies.Append(CookieName, SessionId, new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTimeOffset.Now.AddHours(1),
            Secure = true,
        });
        await httpResponse.StartAsync();
    }

    public async Task SendToken(string token)
    {
        var bodyWriter = new StreamWriter(httpResponse.Body);
        await bodyWriter.WriteLineAsync("event: token");
        await bodyWriter.WriteLineAsync($"data: {token}");
        await bodyWriter.WriteLineAsync();
        await bodyWriter.FlushAsync();
    }
}
