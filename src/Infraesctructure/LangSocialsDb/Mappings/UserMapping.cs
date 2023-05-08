using LangSocials.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangSocials.Infraesctructure.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(u => u.PasswordHash);
        builder.Property(u => u.PasswordSalt);
        builder.Property(u => u.ShowContactInfo);
    }
}
