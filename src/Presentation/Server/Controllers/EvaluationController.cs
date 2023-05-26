using Application.UseCases.Evaluation;
using LangSocials.Presentation.Server.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LangSocials.Presentation.Server.Controllers;
[Route("[Controller]")]
public class EvaluationController : Controller
{
    private readonly ISender sender;

    public EvaluationController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpPost]
    public async Task<IResult> Rating(RatingRequest request, CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Serialize();
    }
}
