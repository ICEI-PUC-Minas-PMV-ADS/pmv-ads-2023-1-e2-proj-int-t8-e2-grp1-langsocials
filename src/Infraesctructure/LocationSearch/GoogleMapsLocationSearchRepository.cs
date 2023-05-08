using Application.Common.Repository.LocationSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LangSocials.Infraesctructure.LocationSearch;

public class GooglePlacesAPILocationSearchRepository : ILocationSearchRepository
{
    private readonly HttpClient googlePlacesAPIClient;

    public GooglePlacesAPILocationSearchRepository(HttpClient googlePlacesAPIClient)
    {
        this.googlePlacesAPIClient = googlePlacesAPIClient;
    }

    public async Task<string?> ClosestPlaceId(string query, CancellationToken cancellationToken = default)
    {
        const string baseRequest = "place/textsearch/json";

        var parsedQuery = $"{baseRequest}?query={query}";
        var response = await googlePlacesAPIClient.GetAsync(parsedQuery, cancellationToken);
        var responseContent = await response.Content.ReadFromJsonAsync<GooglePlaceAPIResult>();
        var firstResult = responseContent?.Results?.FirstOrDefault();
        return firstResult?.place_id;
    }
}
