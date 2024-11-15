using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models;

namespace Reffindr.Infrastructure.Configurations;

public class ApplicationConfiguration : EntityTypeBaseConfiguration<Application>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<Application> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Property)
            .WithMany(x => x.Application)
            .HasForeignKey(x => x.PropertyId);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Applications)
            .HasForeignKey(x => x.UserId);
    }

    protected override void ConfigurateProperties(EntityTypeBuilder<Application> builder)
    {
        builder.Property(x => x.Status)
                .HasMaxLength(10);
    }

    protected override void ConfigurateTableName(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable("Applications");
    }


}
