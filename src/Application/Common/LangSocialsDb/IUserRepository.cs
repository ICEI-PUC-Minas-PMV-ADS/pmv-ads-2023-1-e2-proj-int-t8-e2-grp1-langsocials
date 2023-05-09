using LangSocials.Domain.Entities;

namespace Application.Common.LangSocialsDb
{
    public interface IUserRepository
    {
        void Update(User user);
        Task<bool> IsUniqueName(string name, CancellationToken cancellationToken);
        Task<bool> IsUniqueEmail(string email, CancellationToken cancellationToken);
        Task<User?> Find(int id, CancellationToken cancellationToken);
    }
}
