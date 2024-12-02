using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models;

namespace Reffindr.Infrastructure.Configurations;

public class ImageConfiguration : EntityTypeBaseConfiguration<Image>
{
	protected override void ConfigurateConstraints(EntityTypeBuilder<Image> builder)
	{
		builder.HasKey(x => x.Id);

		builder.HasOne(x => x.Property)
				.WithMany(x => x.Images)
				.HasForeignKey(x => x.PropertyId);
    }

	protected override void ConfigurateProperties(EntityTypeBuilder<Image> builder)
	{
		builder.Property(x => x.ImageUrl)
			.IsRequired()
			.HasMaxLength(500);
	}

	protected override void ConfigurateTableName(EntityTypeBuilder<Image> builder)
	{
		builder.ToTable("Images");
	}
    
}
