﻿using LangSocials.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangSocials.Infraesctructure.LangSocialsDb.Mappings;

public class LocationMapping : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(l => l.Street);
        builder.Property(l => l.PostalCode);
        builder.Property(l => l.State);
        builder.Property(l => l.Number);
        builder.Property(l => l.City);
        builder.Property(l => l.Complement);
        builder.Property(l => l.Neighborhood);
        builder.Property(l => l.Name);
        builder.HasOne(l => l.Owner).WithMany(u => u.Locations).HasForeignKey(l => l.OwnerId);
    }
}
