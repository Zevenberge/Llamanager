namespace Llamanager.Tickets.Abstractions;

public interface ITicketRepository
{
    Task<List<ITicket>> Search(string search, CancellationToken cancellationToken);
}