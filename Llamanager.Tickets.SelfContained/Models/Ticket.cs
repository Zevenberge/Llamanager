using Llamanager.Tickets.SelfContained.Domain;

namespace Llamanager.Tickets.SelfContained.Models;

public record Ticket(
    string Id, 
    string Number, 
    TicketType TicketType,
    Status Status,
    string Summary,
    string? Description,
    string? AcceptanceCriteria)
{
    public Ticket(LlamaTicket ticket)
        : this(ticket.Id, ticket.Number, ticket.Type, ticket.Status,
            ticket.Summary, ticket.Description, ticket.AcceptanceCriteria) { }
}