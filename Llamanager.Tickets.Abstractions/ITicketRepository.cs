namespace Llamanager.Tickets.Abstractions;

public interface ITicketRepository
{
    Task<ITicket?> GetSummaryById(string id, CancellationToken cancellationToken);
    Task<ITicketDetails?> GetDetailsById(string id, CancellationToken cancellationToken);
    Task<List<ITicket>> Search(string search, CancellationToken cancellationToken);
}