using Llamanager.Releasing.Domain;

namespace Llamanager.Releasing.Models;

public record Judgement(
    string Reason,
    Status Status
)
{
    public Judgement(Domain.Judgement judgement)
        : this(judgement.Reason, judgement.Status)
    {
    }
}