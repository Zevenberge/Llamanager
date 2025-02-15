using Llamanager.Tickets.SelfContained.Domain;

namespace Llamanager.Tickets.SelfContained.Repository;

internal class LlamaTicketRepository
{
    // TODO: use persistent backing storage.
    private List<LlamaTicket> _tickets = [];

    public Task<LlamaTicket?> Get(string id, CancellationToken cancellationToken)
    {
        return Task.FromResult(_tickets.FirstOrDefault(t => t.Id == id));
    }

    public Task<List<LlamaTicket>> GetAll(CancellationToken cancellationToken)
    {
        return Task.FromResult(_tickets);
    }

    public Task Add(LlamaTicket ticket, CancellationToken cancellationToken)
    {
        _tickets.Add(ticket);
        return Task.CompletedTask;
    }

    public Task Update(LlamaTicket ticket, CancellationToken cancellationToken)
    {
        // NO-OP for in-memory storage.
        return Task.CompletedTask;
    }

    public Task Delete(LlamaTicket ticket, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}