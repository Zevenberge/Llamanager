namespace Llamanager.Tickets.Abstractions;

public interface ITicketDetails : ITicket
{
    Dictionary<string, string> Details { get; }
}