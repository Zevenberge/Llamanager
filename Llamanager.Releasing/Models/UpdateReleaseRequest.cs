namespace Llamanager.Releasing.Models;

public record UpdateReleaseRequest(
    List<string> Tickets,
    string ReleaseNotes,
    string Consequences, 
    string Countermeasures
);
