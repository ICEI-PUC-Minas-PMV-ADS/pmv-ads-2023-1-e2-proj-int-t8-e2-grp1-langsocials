using Application.Common.LangSocialsDb;
using Application.Common.MediatrExtensions;
using FluentResults;
using FluentValidation;
using LangSocials.Domain.Entities;
using MediatR;

namespace Application.UseCases.Evaluation;

public record RatingRequest(int RatingValue, string Comment, int LocationId, int UserId) : IRequest<Result>;

public class RatingRequestHandler : IRequestHandler<RatingRequest, Result>
{
    private readonly IRatingRopository ratingRopository;
    private readonly ILangSocialsDbUnitOfWork unitOfWork;
    private readonly ILocationRepository locationRepository;
    private readonly IUserRepository userRepository;

    public RatingRequestHandler(IRatingRopository ratingRopository, ILangSocialsDbUnitOfWork unitOfWork, ILocationRepository locationRepository, IUserRepository userRepository)
    {
        this.ratingRopository = ratingRopository;
        this.unitOfWork = unitOfWork;
        this.locationRepository = locationRepository;
        this.userRepository = userRepository;
    }

    public async Task<Result> Handle(RatingRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.Find(request.UserId, cancellationToken);
        if (user is null)
            return Result.Fail(new UnhandledError());

        var location = locationRepository.Find(request.LocationId, cancellationToken);
        if (location is null)
            return Result.Fail(new UnhandledError());

        var vote = new Rating
        {
            RatingValue = request.RatingValue,
            Comment = request.Comment,
            LocationId = request.LocationId,
            UserId = request.UserId
        };

        await ratingRopository.Create(vote, cancellationToken);
        await unitOfWork.SaveChagnes(cancellationToken);

        return Result.Ok();
    }
}

public class RatingRequestValidator : AbstractValidator<RatingRequest>
{
    public RatingRequestValidator()
    {
        RuleFor(rt => rt.RatingValue).NotEmpty();
        RuleFor(rt => rt.Comment).MinimumLength(3).MaximumLength(200);
    }
}