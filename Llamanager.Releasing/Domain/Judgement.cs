namespace Llamanager.Releasing.Domain;

public class Judgement
{
    private Judgement() {}

    public string Reason { get; private set; } = default!;
    public Status Status { get; private set; }

    internal static Judgement Create(string reason, Status status)
    {
        return new Judgement
        {
            Reason = reason,
            Status = status,
        };
    }
}