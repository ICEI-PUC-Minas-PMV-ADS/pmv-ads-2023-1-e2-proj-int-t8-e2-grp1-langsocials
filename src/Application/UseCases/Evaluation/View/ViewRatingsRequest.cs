using Application.Common.LangSocialsDb;
using Application.Common.MediatrExtensions;
using FluentResults;

namespace Application.UseCases.Evaluation.View;
public record ViewRatingsRequest(int LocationId) : IResultRequest<IEnumerable<ViewRatingsResponse>>;

public class ViewRatingsRequestHandler : IResultRequestHandler<ViewRatingsRequest, IEnumerable<ViewRatingsResponse>>
{
    private readonly IRatingRopository ratingRopository;

    public ViewRatingsRequestHandler(IRatingRopository ratingRopository)
    {
        this.ratingRopository = ratingRopository;
    }
    public async Task<Result<IEnumerable<ViewRatingsResponse>>> Handle(ViewRatingsRequest request, CancellationToken cancellationToken)
    {
        var ratings = await ratingRopository.Find(request.LocationId, cancellationToken);

        var response = ratings.Select(r => new ViewRatingsResponse(r.User.Name, r.User.ImageURI, r.RatingValue, r.Comment));

        return response.ToResult();
    }
}

public record ViewRatingsResponse(string UserName, string ImageURI, int RatingValue, string Comment);