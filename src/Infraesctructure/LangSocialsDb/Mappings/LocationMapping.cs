using LangSocials.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangSocials.Infraesctructure.Mappings;

public class LocationMapping : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(l => l.Name);
        builder.Property(l => l.PlaceId);
    }
}
