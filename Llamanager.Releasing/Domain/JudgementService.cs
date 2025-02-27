using System.Runtime.CompilerServices;
using Llamanager.Tickets.Abstractions;

namespace Llamanager.Releasing.Domain;

public class JudgementService(
    ITicketRepository ticketRepository
    ) : IJudgementService
{
    public async Task Judge(ReleaseRequest releaseRequest, CancellationToken cancellationToken)
    {
        var ticketDetails = await GetTicketDetails(releaseRequest.Tickets, cancellationToken).ToArrayAsync(cancellationToken: cancellationToken);

    }

    private async IAsyncEnumerable<ITicketDetails> GetTicketDetails(ReleasedTicket[] tickets, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        foreach (var ticket in tickets)
        {
            var details = await ticketRepository.GetDetailsById(ticket.Id, cancellationToken);
            if (details == null) continue;
            yield return details;
        }
    }
}