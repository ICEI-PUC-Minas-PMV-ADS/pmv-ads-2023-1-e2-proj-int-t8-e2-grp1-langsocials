using Application.Common.LangSocialsDb;
using Application.Common.MediatrExtensions;
using Application.Common.Services;
using FluentResults;
using LangSocials.Domain.Entities;

namespace Application.UseCases.Locations.GetLocationByName;

public record SearchLocationRequest(string Name) : IResultRequest<IEnumerable<SearchLocationResponse>>;

public class SearchLocationRequestHandler : IResultRequestHandler<SearchLocationRequest, IEnumerable<SearchLocationResponse>>
{
    private readonly ILocationRepository locationRepository;
    private readonly IUserInfo userInfo;

    public SearchLocationRequestHandler(ILocationRepository locationRepository, IUserInfo userInfo)
    {
        this.locationRepository = locationRepository;
        this.userInfo = userInfo;
    }

    public async Task<Result<IEnumerable<SearchLocationResponse>>> Handle(SearchLocationRequest request, CancellationToken cancellationToken)
    {
        var allLocations = await locationRepository.Search(request.Name, userInfo.City, userInfo.State, cancellationToken);

        var responses = allLocations.Select(l => new SearchLocationResponse(l));

        return responses.ToResult();
    }
}


// TODO: Create map from Location to LocationResponse
public record SearchLocationResponse(
    int LocationId,
    string Name,
    string Street,
    string PostalCode,
    string Neighborhood,
    string City,
    string State,
    string Number,
    string Complement
)
{
    public SearchLocationResponse(Location location) : this(
        location.Id,
        location.Name,
        location.Street,
        location.PostalCode,
        location.Neighborhood,
        location.City,
        location.State,
        location.Number,
        location.Complement
    )
    { }
};
