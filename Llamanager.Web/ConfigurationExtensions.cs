namespace Llamanager.Web;

public static class ConfigurationExtensions
{
    public static string Frontend(this IConfiguration configuration)
    {
        return configuration["Frontend"] ?? "";
    }

    public static string TicketSource(this IConfiguration configuration)
    {
        return configuration["TicketSource"] ?? "";
    }
}