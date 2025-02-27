namespace Llamanager.Releasing.Models;

public record CreateReleaseRequest(
    List<string> Tickets,
    string ReleaseNotes,
    string Consequences, 
    string Countermeasures
);
