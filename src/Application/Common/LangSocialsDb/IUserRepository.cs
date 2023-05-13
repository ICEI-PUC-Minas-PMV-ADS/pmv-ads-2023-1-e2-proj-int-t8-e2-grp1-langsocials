using LangSocials.Domain.Entities;

namespace Application.Common.LangSocialsDb;

public interface IUserRepository
{
    Task<User?> Find(int id, CancellationToken cancellationToken);
    Task<User?> Find(string email, CancellationToken cancellationToken);
    void Update(User user);
    Task Add(User user, CancellationToken cancellationToken = default);
}
