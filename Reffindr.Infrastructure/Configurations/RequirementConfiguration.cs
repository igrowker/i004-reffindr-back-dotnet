using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models;

namespace Reffindr.Infrastructure.Configurations;

public class RequirementConfiguration : EntityTypeBaseConfiguration<Requirement>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<Requirement> builder)
    {
        builder.HasKey(x => x.Id);
    }

    protected override void ConfigurateProperties(EntityTypeBuilder<Requirement> builder)
    {
        builder.Property(x => x.IsWorking)
            .IsRequired();

        builder.Property(x => x.HasWarranty)
            .IsRequired();

        builder.Property(x => x.RangeSalary)
            .IsRequired()
            .HasPrecision(18, 2);
    }

    protected override void ConfigurateTableName(EntityTypeBuilder<Requirement> builder)
    {
        builder.ToTable("Requirements");
    }
}
