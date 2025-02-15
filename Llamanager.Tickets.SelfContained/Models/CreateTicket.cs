using Llamanager.Tickets.SelfContained.Domain;

namespace Llamanager.Tickets.SelfContained.Models;

internal record CreateTicket(
    TicketType Type, 
    string Summary, 
    string? Description, 
    string? AcceptanceCriteria
);
