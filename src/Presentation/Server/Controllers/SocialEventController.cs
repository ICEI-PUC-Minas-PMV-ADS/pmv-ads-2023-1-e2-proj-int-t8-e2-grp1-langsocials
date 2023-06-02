using Application.UseCases.SocialEvents.GetSocialEventInformation;
using LangSocials.Presentation.Server.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LangSocials.Presentation.Server.Controllers;
public class SocialEventController : ControllerBase
{
    private readonly ISender sender;

    public SocialEventController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpGet("{Id}")]
    public async Task<IResult> GetInformations([FromRoute] uint Id, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetSocialEventInformationRequest(Id), cancellationToken);

        return result.Serialize();
    }
}
