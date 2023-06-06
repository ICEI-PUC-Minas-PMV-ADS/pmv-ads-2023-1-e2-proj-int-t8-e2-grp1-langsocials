using LangSocials.Presentation.Server.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LangSocials.Presentation.Server.Controllers;

[Route("[Controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ISender sender;

    public LocationController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpPost]
    public async Task<IResult> SaveLocation(SaveLocationRequest request, CancellationToken cancellationToken)
    [HttpGet("{Id}")]
    public async Task<IResult> GetLocation(int Id, CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Serialize();
    }

    [HttpGet]
    public async Task<IResult> SearchLocation(SearchLocationRequest request, CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Serialize();
    }

    [HttpPost("claim")]
    public async Task<IResult> ClaimLocation(ClaimLocationRequest request, CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);
        var result = await sender.Send(new GetLocationRequest(Id), cancellationToken);

        return result.Serialize();
    }
}
