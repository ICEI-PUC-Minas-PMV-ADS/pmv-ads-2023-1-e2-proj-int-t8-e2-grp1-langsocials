using Application.UseCases.Locations.GetLocation;
using LangSocials.Presentation.Server.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LangSocials.Presentation.Server.Controllers;
public class LocationController : ControllerBase
{
    private readonly ISender sender;

    public LocationController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpGet("{Id}")]
    public async Task<IResult> GetLocation(int Id, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetLocationRequest(Id), cancellationToken);

        return result.Serialize();
    }
}
