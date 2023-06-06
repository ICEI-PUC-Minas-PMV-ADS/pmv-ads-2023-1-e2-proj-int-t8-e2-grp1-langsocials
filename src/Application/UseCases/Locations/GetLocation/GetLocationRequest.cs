using Application.Common.LangSocialsDb;
using Application.Common.MediatrExtensions;
using AutoMapper;
using FluentResults;

namespace Application.UseCases.Locations.GetLocation;
public record GetLocationRequest(int Id) : IResultRequest<GetLocationResponse>;

public class GetLocationRequestHandler : IResultRequestHandler<GetLocationRequest, GetLocationResponse>
{
    private readonly ILocationRepository locationRepository;
    private readonly IMapper mapper;

    public GetLocationRequestHandler(ILocationRepository locationRepository, IMapper mapper)
    {
        this.locationRepository = locationRepository;
        this.mapper = mapper;
    }
    public async Task<Result<GetLocationResponse>> Handle(GetLocationRequest request, CancellationToken cancellationToken)
    {
        var location = await locationRepository.Find(request.Id, cancellationToken);

        if (location is null)
            return Result.Fail(new UnhandledError());

        var response = mapper.Map<GetLocationResponse>(location);

        return response.ToResult();
    }
}

public record GetLocationResponse(
    string Name,
    string Street, 
    string PostalCode, 
    string Neighborhood, 
    string City, 
    string State,
    string Number, 
    string Description, 
    decimal ConsumptionRequiredValue, 
    int MaximumAmountPeople, 
    string Complement,
    int Avarage);