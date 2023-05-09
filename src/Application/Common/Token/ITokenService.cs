using LangSocials.Domain.Entities;

namespace Application.Common.Token;

public interface ITokenService
{
    string GetToken(User user);
}
