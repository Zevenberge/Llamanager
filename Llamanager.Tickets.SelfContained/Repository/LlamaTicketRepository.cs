using Llamanager.Tickets.SelfContained.Domain;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Llamanager.Tickets.SelfContained.Repository;

internal class LlamaTicketRepository(IAsyncDocumentSession session) : ILlamaTicketRepository
{
    public async Task<LlamaTicket?> Get(string id, CancellationToken cancellationToken)
    {
        return await session.LoadAsync<LlamaTicket>(id, cancellationToken);
    }

    public async Task<List<LlamaTicket>> GetAll(CancellationToken cancellationToken)
    {
        return await session.Query<LlamaTicket>().ToListAsync(cancellationToken);
    }

    public async Task Add(LlamaTicket ticket, CancellationToken cancellationToken)
    {
        await session.StoreAsync(ticket, cancellationToken);
    }

    public async Task Update(LlamaTicket ticket, CancellationToken cancellationToken)
    {
        await session.StoreAsync(ticket, cancellationToken);
    }

    public Task Delete(LlamaTicket ticket, CancellationToken cancellationToken)
    {
        session.Delete(ticket.Id);
        return Task.CompletedTask;
    }
}