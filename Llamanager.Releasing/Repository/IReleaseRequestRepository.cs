using Llamanager.Releasing.Domain;

namespace Llamanager.Releasing.Repository;

public interface IReleaseRequestRepository
{
    Task Add(ReleaseRequest releaseRequest, CancellationToken cancellationToken);
    Task Delete(ReleaseRequest releaseRequest, CancellationToken cancellationToken);
    Task<ReleaseRequest?> Get(string id, CancellationToken cancellationToken);
    Task<List<ReleaseRequest>> GetAll(CancellationToken cancellationToken);
    Task Update(ReleaseRequest releaseRequest, CancellationToken cancellationToken);
}
