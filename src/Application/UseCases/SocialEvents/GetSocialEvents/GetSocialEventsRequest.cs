using Application.Common.LangSocialsDb;
using Application.Common.MediatrExtensions;
using Application.Common.Services;
using AutoMapper;
using FluentResults;
using LangSocials.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.SocialEvents.GetSocialEvents;

public record GetSocialEventsRequest(Location? SearchLocation) : IResultRequest<IEnumerable<GetSocialEventsResponse>>;

public class GetSocialEventsRequestHandler : IResultRequestHandler<GetSocialEventsRequest, IEnumerable<GetSocialEventsResponse>>
{
    const double MaxDistance = 50000;
    private readonly ISocialEventsRepository socialEventsRepository;
    private readonly IUserInfo userInfo;
    private readonly IMapper mapper;

    public GetSocialEventsRequestHandler(ISocialEventsRepository socialEventsRepository, IUserInfo userInfo, IMapper mapper)
    {
        this.socialEventsRepository = socialEventsRepository;
        this.userInfo = userInfo;
        this.mapper = mapper;
    }

    public async Task<Result<IEnumerable<GetSocialEventsResponse>>> Handle(GetSocialEventsRequest request, CancellationToken cancellationToken)
    {
        var searchLocation = request.SearchLocation ?? userInfo.SearchLocation;
        if (searchLocation is null)
            return Result.Fail(new UnhandledError()); // TODO: Refatorar tratamento de erro

        var queriedEvents = socialEventsRepository.QuerySocialEvents((searchLocation.Latitude, searchLocation.Longitude, MaxDistance), cancellationToken: cancellationToken);

        var mappedEvents = mapper.Map<IEnumerable<GetSocialEventsResponse>>(queriedEvents); // TODO: Implementar mapa
        // TODO: Repensar fluxo de localizacao

        return Result.Ok(mappedEvents);
    }
}


public record GetSocialEventsResponse(string placeId, int eventId);
