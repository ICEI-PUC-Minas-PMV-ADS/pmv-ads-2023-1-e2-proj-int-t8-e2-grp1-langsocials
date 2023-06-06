using Application.Common.LangSocialsDb;
using Application.Common.MediatrExtensions;
using AutoMapper;
using FluentResults;

namespace Application.UseCases.SocialEvents.GetSocialEventInformation;
public record GetSocialEventInformationRequest(uint Id) : IResultRequest<GetSocialEventInformationResponse>;


public class GetSocialEventInformationRequestHandler : IResultRequestHandler<GetSocialEventInformationRequest, GetSocialEventInformationResponse>
{
    private readonly ISocialEventsRepository socialEventsRepository;
    private readonly IMapper mapper;

    public GetSocialEventInformationRequestHandler(ISocialEventsRepository socialEventsRepository, IMapper mapper)
    {
        this.socialEventsRepository = socialEventsRepository;
        this.mapper = mapper;
    }

    public async Task<Result<GetSocialEventInformationResponse>> Handle(GetSocialEventInformationRequest request, CancellationToken cancellationToken)
    {
        var socialEvent = await socialEventsRepository.QueryById(request.Id, cancellationToken);

        if (socialEvent is null)
            return Result.Fail(new UnhandledError());

        var response = mapper.Map<GetSocialEventInformationResponse>(socialEvent);

        return response.ToResult();
    }
}

public record GetSocialEventInformationResponse(string Name, DateTime BeginsAt, DateTime EndsAt, string? Description, int LocationId, IEnumerable<GetSocialEventInformationTagResponse> Tags);



public record GetSocialEventInformationTagResponse(string Name);