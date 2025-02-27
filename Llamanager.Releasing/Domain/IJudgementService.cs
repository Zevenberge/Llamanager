namespace Llamanager.Releasing.Domain;

public interface IJudgementService
{
    Task Judge(ReleaseRequest releaseRequest, CancellationToken cancellationToken);
}
