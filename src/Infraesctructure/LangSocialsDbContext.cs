using LangSocials.Domain.Entities;
using LangSocials.Infraesctructure.Mappings;
using Microsoft.EntityFrameworkCore;


namespace LangSocials.Infraesctructure;

public class LangSocialsDbContext : DbContext
{
    public LangSocialsDbContext(DbContextOptions<LangSocialsDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<SocialEvent> SocialEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SocialEventMapping());
        modelBuilder.ApplyConfiguration(new UserMapping());
        modelBuilder.ApplyConfiguration(new LocationMapping());
        base.OnModelCreating(modelBuilder);
    }
}
