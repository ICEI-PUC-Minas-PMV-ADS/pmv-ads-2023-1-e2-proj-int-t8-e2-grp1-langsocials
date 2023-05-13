using Application.Common.Repository.LocationSearch;
using System.Net.Http.Json;

namespace LangSocials.Infraesctructure.LocationSearch;

public class GooglePlacesAPILocationSearchRepository : ILocationSearchRepository
{
    private readonly HttpClient googlePlacesAPIClient;

    public GooglePlacesAPILocationSearchRepository(HttpClient googlePlacesAPIClient)
    {
        this.googlePlacesAPIClient = googlePlacesAPIClient;
    }

    public async Task<(string PlaceId, double Latitude, double Longitude)?> ClosestPlace(string query, CancellationToken cancellationToken = default)
    {
        const string baseRequest = "place/textsearch/json";

        var parsedQuery = $"{baseRequest}?query={query}";
        var response = await googlePlacesAPIClient.GetAsync(parsedQuery, cancellationToken);
        var responseContent = await response.Content.ReadFromJsonAsync<GooglePlaceAPIResult>();
        var firstResult = responseContent?.Results?.FirstOrDefault();

        if (firstResult is null)
            return default;

        return (firstResult.place_id, firstResult.geometry.location.lat, firstResult.geometry.location.lng);
    }
}
