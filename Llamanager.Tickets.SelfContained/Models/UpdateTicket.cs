namespace Llamanager.Tickets.SelfContained.Models;

internal record UpdateTicket(
    string Summary, 
    string? Description, 
    string? AcceptanceCriteria
);
