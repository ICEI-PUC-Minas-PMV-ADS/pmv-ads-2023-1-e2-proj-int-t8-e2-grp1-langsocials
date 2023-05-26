using LangSocials.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangSocials.Infraesctructure.LangSocialsDb.Mappings;

public class SocialEventMapping : IEntityTypeConfiguration<SocialEvent>
{
    public void Configure(EntityTypeBuilder<SocialEvent> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasOne(se => se.Organizer).WithMany(u => u.Organizing);
        builder.HasMany(se => se.Participants).WithMany(u => u.Participating);
        builder.HasOne(se => se.Location).WithMany(l => l.SocialEvents);
        builder.Property(l => l.EndsAt);
        builder.Property(l => l.BeginsAt);
        builder.Property(l => l.Description);
        builder.Property(l => l.Name);
    }
}
