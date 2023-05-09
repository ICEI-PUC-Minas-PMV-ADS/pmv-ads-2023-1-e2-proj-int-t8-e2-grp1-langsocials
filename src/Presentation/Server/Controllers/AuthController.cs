using Application.UseCases.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LangSocials.Presentation.Server.Controllers;
public class AuthController : Controller
{
    private readonly ISender sender;

    public AuthController(ISender sender)
    {
        this.sender = sender;
    }
    public async Task<IResult> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);

        return Results.Ok(result.ValueOrDefault);
    }
}
