using Application.Common.LangSocialsDb;
using Application.Common.MediatrExtensions;
using Application.Common.Services;
using FluentResults;
using MediatR;

namespace Application.UseCases.Locations.ClaimLocation
{
    public record ClaimLocationRequest(
    int Id,
    string Name,
    string Street,
    string PostalCode,
    string City,
    string State,
    string Number,
    string Description,
    string Complement = ""
    ) : IRequest<Result>;

    public class ClaimLocationRequestHandler : IRequestHandler<ClaimLocationRequest, Result>
    {
        private readonly ILangSocialsDbUnitOfWork unitOfWork;
        private readonly ILocationRepository locationRepository;
        private readonly IUserInfo userInfo;

        public ClaimLocationRequestHandler(ILangSocialsDbUnitOfWork unitOfWork, ILocationRepository locationRepository, IUserInfo userInfo)
        {
            this.unitOfWork = unitOfWork;
            this.locationRepository = locationRepository;
            this.userInfo = userInfo;
        }

        public async Task<Result> Handle(ClaimLocationRequest request, CancellationToken cancellationToken)
        {
            var location = await locationRepository.Find(request.Id, cancellationToken);

            if(location is null)
                return Result.Fail(new UnhandledError());

            if(location.OwnerId != 0)
                return Result.Fail(new UnhandledError());

            location.OwnerId = userInfo.Id;

            locationRepository.Update(location);

            await unitOfWork.SaveChagnes(cancellationToken);

            return Result.Ok() ;
        }
    }
}
