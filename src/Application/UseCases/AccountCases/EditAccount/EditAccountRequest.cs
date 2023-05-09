using Application.Common.LangSocialsDb;
using Application.Common.MediatrExtensions;
using Application.Common.Services;
using FluentResults;

namespace Application.UseCases.AccountCases.EditAccount;

public record EditAccountRequest(string Name, string Email, string Description) : IResultRequest;

public class EditAccountRequestHandler : IResultRequestHandler<EditAccountRequest>
{
    private readonly IUserRepository userRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IUserInfo userInfo;
    public EditAccountRequestHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IUserInfo userInfo)
    {
        this.userRepository = userRepository;
        this.unitOfWork = unitOfWork;
        this.userInfo = userInfo;
    }
    public async Task<Result> Handle(EditAccountRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.Find(userInfo.Id, cancellationToken);

        var lowerUsername = request.Name.ToLower();
        var lowerEmail = request.Email.ToLower();
        var lowerDesc = request.Description.ToLower();

        if (user is null)
            return Result.Fail(new UnhandledError());

        if (await userRepository.IsUniqueName(lowerUsername, cancellationToken))
            return Result.Fail(new UnhandledError());

        if (await userRepository.IsUniqueEmail(lowerEmail, cancellationToken))
            return Result.Fail(new UnhandledError());

        user.Name = lowerUsername;
        user.Email = lowerEmail;
        user.Description = lowerDesc;

        userRepository.Update(user);

        await unitOfWork.SaveChagnes(cancellationToken);

        return Result.Ok();
    }
}
