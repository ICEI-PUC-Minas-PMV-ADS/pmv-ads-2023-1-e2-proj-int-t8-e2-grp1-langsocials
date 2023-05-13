using Application.Common.MediatrExtensions;
using Application.Common.Repository.LocationSearch;
using FluentResults;

namespace Application.UseCases.Locations.GetLocationByName;

public record SearchLocationRequest(string Name) : IResultRequest<SearchLocationResponse>;

public class SearchLocationRequestHandler : IResultRequestHandler<SearchLocationRequest, SearchLocationResponse>
{
    private readonly ILocationSearchRepository locationSearchRepository;

    public SearchLocationRequestHandler(ILocationSearchRepository locationSearchRepository)
    {
        this.locationSearchRepository = locationSearchRepository;
    }

    public async Task<Result<SearchLocationResponse>> Handle(SearchLocationRequest request, CancellationToken cancellationToken)
    {
        var closestPlace = await locationSearchRepository.ClosestPlace(request.Name, cancellationToken);

        if (closestPlace is null)
            return Result.Ok<SearchLocationResponse>(default!);

        return new SearchLocationResponse(closestPlace.Value.PlaceId, closestPlace.Value.Latitude, closestPlace.Value.Longitude).ToResult();
    }
}

public record SearchLocationResponse(string PlaceId, double Latitude, double Longitude);
