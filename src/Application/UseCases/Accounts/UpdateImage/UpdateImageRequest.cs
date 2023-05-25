using Application.Common.LangSocialsDb;
using Application.Common.MediatrExtensions;
using Application.Common.Services;
using Application.Common.Services.Files;
using FluentResults;
using MediatR;

namespace Application.UseCases.Accounts.UpdateImage;

public record UpdateImageRequest(Stream ImageStream, string Extension) : IRequest<Result<UpdateImageRequestResponse>>;

public class UpdateImageRequestHandler : IRequestHandler<UpdateImageRequest, Result<UpdateImageRequestResponse>>
{
    private readonly ILangSocialsDbUnitOfWork unitOfWork;
    private readonly IUserRepository userRepository;
    private readonly IFileService fileRepository;
    private readonly IUserInfo userInfo;
    public UpdateImageRequestHandler(ILangSocialsDbUnitOfWork unitOfWork,IUserRepository userRepository,IFileService fileRepository,IUserInfo userInfo)
    {
        this.unitOfWork = unitOfWork;
        this.userRepository = userRepository;
        this.fileRepository = fileRepository;
        this.userInfo = userInfo;
    }
    public async Task<Result<UpdateImageRequestResponse>> Handle(UpdateImageRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.Find(userInfo.Id, cancellationToken);

        if (user is null)
            return Result.Fail(new UnhandledError());

        byte[] byt = new byte[request.ImageStream.Length];
        request.ImageStream.Read(byt, 0, byt.Length);

        if (request is null)
        {
            fileRepository.DeleteImage(user.ImageURI);
            user.ImageURI = fileRepository.DefaultUserImagePath;
        }
        else
            user.ImageURI = fileRepository.UpdateImage(user.ImageURI, "/Users/",
                new FileImage(request.Extension!, Guid.NewGuid().ToString(), byt));

        userRepository.Update(user);
        await unitOfWork.SaveChagnes(cancellationToken);
        return Result.Ok(new UpdateImageRequestResponse(user.ImageURI));
    }
}

public record UpdateImageRequestResponse(string ImageURI);