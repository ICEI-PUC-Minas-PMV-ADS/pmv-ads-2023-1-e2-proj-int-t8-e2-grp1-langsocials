using Application.UseCases.Accounts.UpdateImage;
using Application.UseCases.Accounts.EditAccount;
using LangSocials.Presentation.Server.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.UseCases.Accounts.Registration;
using Microsoft.AspNetCore.Authorization;

namespace LangSocials.Presentation.Server.Controllers;

[ApiController]
[Route("[Controller]")]
public class AccountController : ControllerBase
{
    private readonly ISender sender;

    public AccountController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpPut]
    [Authorize]
    public async Task<IResult> EditAccount(UpdateAccountInfoRequest request, CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Serialize();
    }

    [HttpPut("image")]
    public async Task<IResult> UpdateImageAccount(IFormFile request, CancellationToken cancellationToken)
    {
        var streamImage = new MemoryStream();
        request?.CopyTo(streamImage);
        var result = await sender.Send(new UpdateImageRequest(streamImage, request!.ContentType.Replace("image/", ".")), cancellationToken);
        return result.Serialize();
    }

    [HttpPost]
    [Authorize]
    public async Task<IResult> RegisterAccount(RegistrationRequest request, CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Serialize();
    }
}
