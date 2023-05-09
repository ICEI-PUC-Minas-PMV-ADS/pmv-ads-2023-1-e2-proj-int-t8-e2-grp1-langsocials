using Application.UseCases.AccountCases.EditAccount;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LangSocials.Presentation.Server.Controllers
{
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
        public async Task<IResult> EditAccount(EditAccountRequest request, CancellationToken cancellationToken)
        {
            var result = await sender.Send(request, cancellationToken);

            return Results.Ok(result);
        }
    }
}
