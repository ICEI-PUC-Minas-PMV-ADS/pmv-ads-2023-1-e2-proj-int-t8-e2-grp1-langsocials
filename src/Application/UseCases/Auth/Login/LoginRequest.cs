using Application.Common.Cryptography;
using Application.Common.LangSocialsDb;
using Application.Common.MediatrExtensions;
using Application.Common.Token;
using FluentResults;

namespace Application.UseCases.Auth.Login;

public record LoginRequest(string Email, string Password) : IResultRequest<LoginResponse>;

public class LoginRequestHandler : IResultRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IUserRepository userRepository;
    private readonly ICryptographyService cryptographyService;
    private readonly ITokenService tokenService;

    public LoginRequestHandler(IUserRepository userRepository, ICryptographyService cryptographyService, ITokenService tokenService)
    {
        this.userRepository = userRepository;
        this.cryptographyService = cryptographyService;
        this.tokenService = tokenService;
    }
    public async Task<Result<LoginResponse>> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.Find(request.Email, cancellationToken);
        
        if (user is null)
            return Result.Fail(new UnhandledError());

        if (!cryptographyService.Compare(request.Password, user.PasswordSalt, user.PasswordHash))
            return Result.Fail(new UnhandledError());

        var token = tokenService.GetToken(user);

        var ownerLocations = user.Locations.Select(ol => (ol.Name, ol.Id));

        return new LoginResponse(token, user.Name, user.Email, ownerLocations).ToResult();
    }
}

public record LoginResponse(string Token, string Name, string Email, IEnumerable<(string Name, int LocationId)> OwnedLocations);