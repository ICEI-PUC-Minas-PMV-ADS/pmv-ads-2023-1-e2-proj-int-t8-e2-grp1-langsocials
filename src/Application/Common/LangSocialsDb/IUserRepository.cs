using LangSocials.Domain.Entities;

namespace Application.Common.LangSocialsDb;
public interface IUserRepository
{
    Task<User> Find(string email, CancellationToken cancellationToken);
}
