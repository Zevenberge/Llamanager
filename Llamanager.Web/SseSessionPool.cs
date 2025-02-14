using System.Collections.Concurrent;

namespace Llamanager.Web;

public class SseSessionPool
{
    private readonly ConcurrentDictionary<string, ServerSentEventStream> _sessions = new();

    public async Task AddOpenedEventStream(HttpContext httpContext)
    {
        var eventStream = new ServerSentEventStream(httpContext.Response);
        _sessions.TryAdd(eventStream.SessionId, eventStream);
        httpContext.RequestAborted.Register(() => _sessions.Remove(eventStream.SessionId, out _));
        await eventStream.Open();
    }

    public ServerSentEventStream? TryGetEventStream(HttpContext httpContext)
    {
        var cookies = httpContext.Request.Cookies;
        if(cookies.TryGetValue(ServerSentEventStream.CookieName, out var sessionId))
        {
            _sessions.TryGetValue(sessionId, out var serverSentEventStream);
            return serverSentEventStream;
        }
        return null;
    }
}