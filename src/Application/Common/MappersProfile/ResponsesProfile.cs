using Application.UseCases.SocialEvents.GetSocialEventInformation;
using AutoMapper;
using LangSocials.Domain.Entities;

namespace Application.Common.MappersProfile;
public class ResponsesProfile : Profile
{
    public ResponsesProfile()
    {
        CreateMap<SocialEvent, GetSocialEventInformationResponse>()
            .ForCtorParam("Tags", cese => cese.MapFrom(se => se.Tags));
    }
}
