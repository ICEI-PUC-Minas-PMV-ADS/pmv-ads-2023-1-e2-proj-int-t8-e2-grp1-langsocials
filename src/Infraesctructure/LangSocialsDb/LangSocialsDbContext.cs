using Application.Common.LangSocialsDb;
using LangSocials.Domain.Entities;
using LangSocials.Infraesctructure.LangSocialsDb.Mappings;
using LangSocials.Infraesctructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace LangSocials.Infraesctructure.LangSocialsDb;

public class LangSocialsDbContext : DbContext, ILangSocialsDbUnitOfWork
{
    public LangSocialsDbContext(DbContextOptions<LangSocialsDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<SocialEvent> SocialEvents { get; set; }
    public DbSet<LocationClaim> LocationClaims { get; set; }

    public async Task SaveChagnes(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SocialEventMapping());
        modelBuilder.ApplyConfiguration(new UserMapping());
        modelBuilder.ApplyConfiguration(new LocationMapping());
        modelBuilder.ApplyConfiguration(new LocationClaimMapping());
        base.OnModelCreating(modelBuilder);
    }
}
