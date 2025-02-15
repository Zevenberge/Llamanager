namespace Llamanager.Web;

public static class ServerSentEventStreamExtensions
{
    public static async Task SendTokens(this ServerSentEventStream serverSentEventStream, IAsyncEnumerable<string> tokens)
    {
        await foreach(var token in tokens)
        {
            await serverSentEventStream.SendToken(token);
        }
    }
}
