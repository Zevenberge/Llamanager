using Llamanager.Tickets.Abstractions;

namespace Llamanager.Releasing.Domain;

public class ReleaseRequest
{
    private ReleaseRequest() {}
    public string Id { get; private set; } = default!;
    public string Number => Id.Split('/').LastOrDefault() ?? "";
    public ReleasedTicket[] Tickets { get; private set; } = [];
    public string ReleaseNotes { get; private set; } = "";
    public string Consequences { get; private set; } = "";
    public string Countermeasures { get; private set; } = "";
    public List<Judgement> Judgements { get; private set; } = [];
    public Status Status { get; private set; }

    public static ReleaseRequest Create(ITicket[] tickets, string releaseNotes, string consequences, string countermeasures)
    {
        return new ReleaseRequest
        {
            Tickets = [..tickets.Select(ReleasedTicket.Copy)],
            ReleaseNotes = releaseNotes,
            Consequences = consequences,
            Countermeasures = countermeasures,
            Status = Status.Pending,
        };
    }

    public void Update(ITicket[] tickets, string releaseNotes, string consequences, string countermeasures)
    {
        Tickets = [..tickets.Select(ReleasedTicket.Copy)];
        ReleaseNotes = releaseNotes;
        Consequences = consequences;
        Countermeasures = countermeasures;
    }

    public void AddJudgement(string reason, Status status)
    {
        Judgements.Add(Judgement.Create(reason, status));
        Status = status;
    }

    public void Reopen()
    {
        Status = Status.Pending;
    }
}
