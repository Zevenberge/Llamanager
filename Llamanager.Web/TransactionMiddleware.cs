using Raven.Client.Documents.Session;

namespace Llamanager.Web;

public static class TransactionMiddleware
{
    public static void UseTransactions(this WebApplication app)
    {
        app.Use((context, next) =>
        {
            if(IsReadOnly(context))
            {
                return next();
            }
            return UseTransaction(context, next);
        });
    }

    private static bool IsReadOnly(HttpContext httpContext)
    {
        return string.Equals(httpContext.Request.Method, "GET", StringComparison.InvariantCultureIgnoreCase);
    }

    private static async Task UseTransaction(HttpContext context, Func<Task> next)
    {
        await next();
        if(context.Response.StatusCode is < 200 or >= 300) return; // An error occured
        var activeSession = context.RequestServices.GetService<IAsyncDocumentSession>();
        if(activeSession == null) return;
        await activeSession.SaveChangesAsync();
    }
}
