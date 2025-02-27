using Llamanager.Releasing.Domain;

namespace Llamanager.Releasing.Models;

public record ReleaseSummary(
    string Id,
    string Number,
    Status Status,
    List<Ticket> Tickets
)
{
    public ReleaseSummary(Domain.ReleaseRequest releaseRequest)
        : this(releaseRequest.Id, releaseRequest.Number, releaseRequest.Status,
            [..releaseRequest.Tickets.Select(t => new Ticket(t))])
    {
    }
}
