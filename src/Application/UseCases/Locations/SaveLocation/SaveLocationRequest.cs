using Application.Common.LangSocialsDb;
using Application.Common.MediatrExtensions;
using FluentResults;
using LangSocials.Domain.Entities;

namespace Application.UseCases.Locations.SaveLocation;

public record SaveLocationRequest(
    string Name,
    string Street,
    string PostalCode,
    string Neighborhood,
    decimal ConsumptionValue,
    string City,
    string State,
    string Number,
    string Description,
    string Complement = ""
) : IResultRequest;

public class SaveLocationRequestHandler : IResultRequestHandler<SaveLocationRequest>
{
    private readonly ILocationRepository locationRepository;
    private readonly ILangSocialsDbUnitOfWork unitOfWork;

    public SaveLocationRequestHandler(ILocationRepository locationRepository, ILangSocialsDbUnitOfWork unitOfWork)
    {
        this.locationRepository = locationRepository;
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(SaveLocationRequest request, CancellationToken cancellationToken)
    {
        if (await locationRepository.AlreadyExists(request.Name, request.Street, request.Number, request.PostalCode, cancellationToken))
            return Result.Fail(new UnhandledError());

        var location = new Location
        {
            Name = request.Name,
            Street = request.Street,
            PostalCode = request.PostalCode,
            Neighborhood = request.Neighborhood,
            City = request.City,
            State = request.State,
            Number = request.Number,
            Description = request.Description,
            ConsumptionRequiredValue = request.ConsumptionValue,
            Complement = request.Complement
        };

        await locationRepository.Add(location, cancellationToken);

        await unitOfWork.SaveChagnes(cancellationToken);

        return Result.Ok();
    }
}
