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

    public Task<User?> Find(int id, CancellationToken cancellationToken)
    {
        return context.Users.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    }

    public Task<User?> Find(string email, CancellationToken cancellationToken)
    {
        return context.Users.FirstOrDefaultAsync(a => a.Email == email, cancellationToken);
    }

    public void Update(User user)
    {
        context.Update(user);
    }

    public async Task Add(User user, CancellationToken cancellationToken = default)
    {
        await context.Users.AddAsync(user, cancellationToken);
    }
}
