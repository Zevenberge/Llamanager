using Llamanager.Tickets.Abstractions;

namespace Llamanager.Tickets.SelfContained.Domain;

public class LlamaTicket : ITicket
{
    private LlamaTicket() { }
    public string Id { get; private set; } = default!;
    public string Number => Id.Split('/').LastOrDefault() ?? "";

    public TicketType Type { get; private set; }
    public string Summary { get; private set; } = "";
    public string? Description { get; private set; }
    public string? AcceptanceCriteria { get; private set; }
    public Status Status { get; private set; }

    public static LlamaTicket Create(TicketType ticketType, string summary, string? description, string? acceptanceCriteria)
    {
        return new LlamaTicket
        {
            Type = ticketType,
            Summary = summary,
            Description = description,
            AcceptanceCriteria = acceptanceCriteria,
            Status = Status.Open,
        };
    }

    public void Update(string summary, string? description, string? acceptanceCriteria)
    {
        Summary = summary;
        Description = description;
        AcceptanceCriteria = acceptanceCriteria;
    }

    public void UpdateStatus(Status status)
    {
        Status = status;
    }

    public void ChangeTicketType(TicketType ticketType)
    {
        Type = ticketType;
    }
}
