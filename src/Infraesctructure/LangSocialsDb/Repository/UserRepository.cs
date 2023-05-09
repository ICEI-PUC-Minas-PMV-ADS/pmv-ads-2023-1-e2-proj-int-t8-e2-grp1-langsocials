using Application.Common.LangSocialsDb;
using LangSocials.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LangSocials.Infraesctructure.LangSocialsDb.Repository;

public class UserRepository : IUserRepository
{
    private readonly LangSocialsDbContext context;

    public UserRepository(LangSocialsDbContext context)
    {
        this.context = context;
    }

    public async Task<User?> Find(int id, CancellationToken cancellationToken)
       => await context.Users.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    public async Task<bool> IsUniqueName(string name, CancellationToken cancellationToken)
       => await context.Users.AnyAsync(a => a.Name == name, cancellationToken);
    public async Task<bool> IsUniqueEmail(string email, CancellationToken cancellationToken)
       => await context.Users.AnyAsync(a => a.Email == email, cancellationToken);
    public void Update(User user)
       => context.Update(user);
}
