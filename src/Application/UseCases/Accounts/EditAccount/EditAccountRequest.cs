using Application.Common.LangSocialsDb;
using Application.Common.MediatrExtensions;
using Application.Common.Services;
using FluentResults;

namespace Application.UseCases.AccountCases.EditAccount;

public record UpdateAccountInfoRequest(string? Name, string? Description) : IResultRequest;

public class EditAccountRequestHandler : IResultRequestHandler<UpdateAccountInfoRequest>
{
    private readonly IUserRepository userRepository;
    private readonly ILangSocialsDbUnitOfWork unitOfWork;
    private readonly IUserInfo userInfo;
    public EditAccountRequestHandler(IUserRepository userRepository, ILangSocialsDbUnitOfWork unitOfWork, IUserInfo userInfo)
    {
        this.userRepository = userRepository;
        this.unitOfWork = unitOfWork;
        this.userInfo = userInfo;
    }
    public async Task<Result> Handle(UpdateAccountInfoRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.Find(userInfo.Id, cancellationToken);

        // TODO: Refatorar tratamento de erros
        if (user is null)
            return Result.Fail(new UnhandledError());

        if (request.Name is { } requestName)
            user.Name = requestName;

        if (request.Description is { } requestDescription)
            user.Description = requestDescription;

        userRepository.Update(user);

        await unitOfWork.SaveChagnes(cancellationToken);

        return Result.Ok();
    }
}
