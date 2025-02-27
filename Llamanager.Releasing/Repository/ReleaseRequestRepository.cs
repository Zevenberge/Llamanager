using Llamanager.Releasing.Domain;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Llamanager.Releasing.Repository;

public class ReleaseRequestRepository(IAsyncDocumentSession session) : IReleaseRequestRepository
{
    public async Task<ReleaseRequest?> Get(string id, CancellationToken cancellationToken)
    {
        return await session.LoadAsync<ReleaseRequest>(id, cancellationToken);
    }

    public async Task<List<ReleaseRequest>> GetAll(CancellationToken cancellationToken)
    {
        return await session.Query<ReleaseRequest>().ToListAsync(token: cancellationToken);
    }

    public async Task Add(ReleaseRequest releaseRequest, CancellationToken cancellationToken)
    {
        await session.StoreAsync(releaseRequest, cancellationToken);
    }

    public async Task Update(ReleaseRequest releaseRequest, CancellationToken cancellationToken)
    {
        await session.StoreAsync(releaseRequest, cancellationToken);
    }

    public Task Delete(ReleaseRequest releaseRequest, CancellationToken cancellationToken)
    {
        session.Delete(releaseRequest.Id);
        return Task.CompletedTask;
    }
}