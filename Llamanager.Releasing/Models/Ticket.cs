using System.Text.Json.Serialization;
using Llamanager.Releasing.Domain;

namespace Llamanager.Releasing.Models;

[method: JsonConstructor]
public record Ticket(
    string Id,
    string Number,
    string Summary
)
{
    public Ticket(ReleasedTicket releasedTicket)
        : this(releasedTicket.Id, releasedTicket.Number, releasedTicket.Summary)
    {
    }
}