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
        var placeId = await locationSearchRepository.ClosestPlaceId(request.Name, cancellationToken);

        return new SearchLocationResponse(placeId).ToResult();
    }
}

public record SearchLocationResponse(string? PlaceId);
