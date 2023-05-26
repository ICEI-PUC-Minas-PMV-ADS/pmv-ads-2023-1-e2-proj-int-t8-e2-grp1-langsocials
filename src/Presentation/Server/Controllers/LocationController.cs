using Application.UseCases.Auth.Login;
using Application.UseCases.Locations.ClaimLocation;
using Application.UseCases.Locations.SaveLocation;
using Application.UseCases.Locations.SearchLocation;
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

        return result.Serialize();
    }
}
