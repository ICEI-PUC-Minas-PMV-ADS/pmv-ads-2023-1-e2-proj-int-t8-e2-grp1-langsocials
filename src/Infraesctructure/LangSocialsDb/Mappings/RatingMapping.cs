using LangSocials.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangSocials.Infraesctructure.LangSocialsDb.Mappings;

public class RatingMapping : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.RatingValue);
        builder.Property(x => x.Comment).HasMaxLength(200);
        builder.HasOne(x => x.User).WithMany(x => x.Ratings).HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.Location).WithMany(x => x.Ratings).HasForeignKey(x => x.LocationId);
    }
}
