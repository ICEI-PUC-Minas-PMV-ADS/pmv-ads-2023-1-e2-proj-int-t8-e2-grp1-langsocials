using Application.Common.LangSocialsDb;
using Application.Common.MediatrExtensions;
using FluentResults;
using LangSocials.Domain.Entities;

namespace Application.UseCases.Locations.SaveLocation;

public record SaveLocationRequest(string Name, string PlaceId, double Latitude, double Longitude) : IResultRequest;

public class SaveLocationRequestHandler : IResultRequestHandler<SaveLocationRequest>
{
    private readonly ILocationRepository locationRepository;

    public SaveLocationRequestHandler(ILocationRepository locationRepository)
    {
        this.locationRepository = locationRepository;
    }
    public async Task<Result> Handle(SaveLocationRequest request, CancellationToken cancellationToken)
    {
        var location = new Location
        {
            Name = request.Name,
            PlaceId = request.PlaceId,
            SocialEvents = new List<SocialEvent>()
        };

        await locationRepository.Add(location, cancellationToken);

        return Result.Ok();
    }
}
