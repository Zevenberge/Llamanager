namespace Llamanager.Tickets.SelfContained.Models;

public record UpdateTicket(
    string Summary, 
    string? Description, 
    string? AcceptanceCriteria
);
