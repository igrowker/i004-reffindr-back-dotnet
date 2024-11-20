using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models;

namespace Reffindr.Infrastructure.Configurations;

public class ApplicationConfiguration : EntityTypeBaseConfiguration<ApplicationModel>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<ApplicationModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Property)
            .WithMany(x => x.Application)
            .HasForeignKey(x => x.PropertyId);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Applications)
            .HasForeignKey(x => x.UserId);
    }

    protected override void ConfigurateProperties(EntityTypeBuilder<ApplicationModel> builder)
    {
        builder.Property(x => x.Status)
                .HasMaxLength(10);
    }

    protected override void ConfigurateTableName(EntityTypeBuilder<ApplicationModel> builder)
    {
        builder.ToTable("Applications");
    }


}
