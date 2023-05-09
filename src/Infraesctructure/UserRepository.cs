using Application.Common.LangSocialsDb;
using LangSocials.Domain.Entities;
using LangSocials.Infraesctructure.LangSocialsDb;
using Microsoft.EntityFrameworkCore;

namespace LangSocials.Infraesctructure;
public class UserRepository : IUserRepository
{
    private readonly LangSocialsDbContext context;

    public UserRepository(LangSocialsDbContext context)
    {
        this.context = context;
    }
    public Task<User?> Find(string email, CancellationToken cancellationToken)
        => context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
}
