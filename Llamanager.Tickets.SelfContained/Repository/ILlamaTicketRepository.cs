using Llamanager.Tickets.SelfContained.Domain;

namespace Llamanager.Tickets.SelfContained.Repository;

public interface ILlamaTicketRepository
{
    Task Add(LlamaTicket ticket, CancellationToken cancellationToken);
    Task Delete(LlamaTicket ticket, CancellationToken cancellationToken);
    Task<LlamaTicket?> Get(string id, CancellationToken cancellationToken);
    Task<List<LlamaTicket>> GetAll(CancellationToken cancellationToken);
    Task Update(LlamaTicket ticket, CancellationToken cancellationToken);
}
