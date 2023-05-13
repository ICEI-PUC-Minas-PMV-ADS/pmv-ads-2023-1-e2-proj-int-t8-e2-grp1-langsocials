using LangSocials.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangSocials.Infraesctructure.LangSocialsDb.Mappings;

public class LocationClaimMapping : IEntityTypeConfiguration<LocationClaim>
{
    public void Configure(EntityTypeBuilder<LocationClaim> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.User).WithMany(x => x.LocationClaims);
        builder.HasOne(x => x.Location).WithOne(x => x.Claim).HasForeignKey<LocationClaim>(x=>x.LocationId);
    }
}
