using Application.Common.LangSocialsDb;
using Application.Common.MediatrExtensions;
using AutoMapper;
using FluentResults;

namespace Application.UseCases.SocialEvents.GetSocialEvents;

public record GetSocialEventsRequest(string CityFilter, string StateFilter) : IResultRequest<IEnumerable<GetSocialEventsResponse>>;

public class GetSocialEventsRequestHandler : IResultRequestHandler<GetSocialEventsRequest, IEnumerable<GetSocialEventsResponse>>
{
    private readonly ISocialEventsRepository socialEventsRepository;
    private readonly IMapper mapper;

    public GetSocialEventsRequestHandler(ISocialEventsRepository socialEventsRepository, IMapper mapper)
    {
        this.socialEventsRepository = socialEventsRepository;
        this.mapper = mapper;
    }

    public async Task<Result<IEnumerable<GetSocialEventsResponse>>> Handle(GetSocialEventsRequest request, CancellationToken cancellationToken)
    {
        var queriedEvents = await socialEventsRepository.QuerySocialEvents(request.CityFilter, request.StateFilter, cancellationToken: cancellationToken);

        var mappedEvents = mapper.Map<IEnumerable<GetSocialEventsResponse>>(queriedEvents); // TODO: Implementar mapa

        return Result.Ok(mappedEvents);
    }
}


public record GetSocialEventsResponse(string placeId, int eventId);
