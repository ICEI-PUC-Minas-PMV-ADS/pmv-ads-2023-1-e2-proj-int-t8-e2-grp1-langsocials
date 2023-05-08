namespace Application.Common.Repository.LocationSearch;

public interface ILocationSearchRepository
{
    Task<string?> ClosestPlaceId(string query, CancellationToken cancellationToken = default);
}
