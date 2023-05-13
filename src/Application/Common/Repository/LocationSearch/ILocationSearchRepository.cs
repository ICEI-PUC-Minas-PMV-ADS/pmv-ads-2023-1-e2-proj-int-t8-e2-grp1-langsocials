namespace Application.Common.Repository.LocationSearch;

public interface ILocationSearchRepository
{
    Task<(string PlaceId, double Latitude, double Longitude)?> ClosestPlace(string query, CancellationToken cancellationToken = default);
}
