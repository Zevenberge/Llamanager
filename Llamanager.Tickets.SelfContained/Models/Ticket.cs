using Llamanager.Tickets.SelfContained.Domain;

namespace Llamanager.Tickets.SelfContained.Models;

public record Ticket(string Id, string Number, string Summary)
{
    public Ticket(LlamaTicket ticket)
        : this(ticket.Id, ticket.Number, ticket.Summary) { }
}