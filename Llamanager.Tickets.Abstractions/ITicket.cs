namespace Llamanager.Tickets.Abstractions;

public interface ITicket
{
    /// <summary>
    /// The system ID of the ticket, e.g. a guid.
    /// </summary>
    string Id { get; }
    /// <summary>
    /// The human-readable reference to a ticket, e.g. 12345 (DevOps) or L-123 (Jira).
    /// </summary>
    string Number { get; }
    /// <summary>
    /// A short description of the ticket, intended to be displayed on a single line. Usually the title.
    /// </summary>
    string Summary { get; }
}
