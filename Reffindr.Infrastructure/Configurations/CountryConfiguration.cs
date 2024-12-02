﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models;

namespace Reffindr.Infrastructure.Configurations;

public class CountryConfiguration : EntityTypeBaseConfiguration<Country>
{
	protected override void ConfigurateConstraints(EntityTypeBuilder<Country> builder)
	{
		builder.HasKey(x => x.Id);

		builder.HasMany(x => x.State)
			.WithOne(x => x.Country);

		builder.HasMany(x => x.Property).WithOne(x => x.Country).HasForeignKey(x => x.CountryId);
	}

	protected override void ConfigurateProperties(EntityTypeBuilder<Country> builder)
	{
		builder.Property(x => x.CountryName)
			.IsRequired()
			.HasMaxLength(100);
	}

	protected override void ConfigurateTableName(EntityTypeBuilder<Country> builder)
	{
		builder.ToTable("Countries");
	}

	protected override void SeedData(EntityTypeBuilder<Country> builder)
	{
	
		builder.HasData(
            new Country
            {
                Id = 1,
                CountryName = "Argentina",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
                IsDeleted = false
            }
        );
	}
}
