
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models;

namespace Reffindr.Infrastructure.Configurations;

public class PropertyConfigurations : EntityTypeBaseConfiguration<Property>
{
	protected override void ConfigurateConstraints(EntityTypeBuilder<Property> builder)
	{
		builder.HasKey(x => x.Id);

		builder.HasOne(x => x.Requirement)
			.WithOne(x => x.Property)
			.HasForeignKey<Property>(x => x.RequirementId);

		builder.HasOne(x => x.Country)
			.WithMany()
			.HasForeignKey(x => x.CountryId);

		builder.HasOne(x => x.State)
			.WithMany()
			.HasForeignKey(x => x.StateId);

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
