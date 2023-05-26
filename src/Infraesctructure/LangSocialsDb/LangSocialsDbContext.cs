using Application.Common.LangSocialsDb;
using LangSocials.Domain.Entities;
using LangSocials.Infraesctructure.LangSocialsDb.Mappings;
using Microsoft.EntityFrameworkCore;

namespace LangSocials.Infraesctructure.LangSocialsDb;

public class LangSocialsDbContext : DbContext, ILangSocialsDbUnitOfWork
{
    public LangSocialsDbContext(DbContextOptions<LangSocialsDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<SocialEvent> SocialEvents { get; set; }
    public DbSet<LocationClaim> LocationClaims { get; set; }
    public DbSet<Rating> Ratings { get; set; }

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
        modelBuilder.ApplyConfiguration(new RatingMapping());
        base.OnModelCreating(modelBuilder);
    }
}
