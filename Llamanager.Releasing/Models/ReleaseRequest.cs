using Llamanager.Releasing.Domain;

namespace Llamanager.Releasing.Models;

public record ReleaseRequest(
    string Id,
    string Number,
    Status Status,
    List<Ticket> Tickets,
    string ReleaseNotes,
    string Consequences, 
    string Countermeasures,
    List<Judgement> Judgements 
)
{
    public ReleaseRequest(Domain.ReleaseRequest releaseRequest)
        : this(releaseRequest.Id, releaseRequest.Number, releaseRequest.Status,
            [..releaseRequest.Tickets.Select(t => new Ticket(t))],
            releaseRequest.ReleaseNotes, releaseRequest.Consequences, releaseRequest.Countermeasures,
            [..releaseRequest.Judgements.Select(j => new Judgement(j))])
    {
    }
}
