using Llamanager.Tickets.Abstractions;

namespace Llamanager.Releasing.Domain;

public class ReleasedTicket : ITicket
{
    private ReleasedTicket() {}
    public string Id { get; private set; } = default!;
    public string Number { get; private set; } = default!;
    public string Summary { get; private set; } = default!;

    public static ReleasedTicket Copy(ITicket original)
    {
        return new ReleasedTicket
        {
            Id = original.Id,
            Number = original.Number,
            Summary = original.Summary,
        };
    }
}