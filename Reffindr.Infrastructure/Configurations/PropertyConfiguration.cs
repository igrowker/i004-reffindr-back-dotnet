
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models;

namespace Reffindr.Infrastructure.Configurations;

public class PropertyConfiguration : EntityTypeBaseConfiguration<Property>
{
	protected override void ConfigurateConstraints(EntityTypeBuilder<Property> builder)
	{
		builder.HasKey(x => x.Id);

		builder.HasOne(x => x.Requirement)
			.WithOne(x => x.Property)
			.HasForeignKey<Property>(x => x.RequirementId);

		builder.HasOne(x => x.Country)
			.WithMany(x => x.Property)
			.HasForeignKey(x => x.CountryId);

		builder.HasOne(x => x.State)
			.WithMany(x => x.Property)
			.HasForeignKey(x => x.StateId);

        builder.HasMany(x => x.Application)
			.WithOne(x => x.Property)
			.HasForeignKey(x => x.PropertyId);

		builder.HasOne(x => x.Notification)
		.WithOne(x => x.Property)
		.HasForeignKey<Notification>(x => x.PropertyId);

        builder.HasMany(x => x.Images)
            .WithOne(x => x.Property)
            .HasForeignKey(x => x.PropertyId);


    }

	protected override void ConfigurateProperties(EntityTypeBuilder<Property> builder)
	{
		builder.Property(x => x.Title)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(x => x.Address)
			.IsRequired()
			.HasMaxLength(1000);

		builder.Property(x => x.Description)
			.IsRequired()
			.HasMaxLength(1000);
	}

	protected override void ConfigurateTableName(EntityTypeBuilder<Property> builder)
	{
		builder.ToTable("Properties");
	}
}
