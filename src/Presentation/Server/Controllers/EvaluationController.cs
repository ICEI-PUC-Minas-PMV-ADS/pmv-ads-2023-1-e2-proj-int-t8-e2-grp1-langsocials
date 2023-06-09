using Application.UseCases.Evaluation.Ratings;
using Application.UseCases.Evaluation.View;
using LangSocials.Presentation.Server.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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
    [Authorize]
    public async Task<IResult> Rating(RatingRequest request, CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Serialize();
    }

    [HttpGet("{LocationId}")]
    [Authorize]
    public async Task<IResult> ViewRating(int LocationId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new ViewRatingsRequest(LocationId), cancellationToken);

        return result.Serialize();
    }
}
