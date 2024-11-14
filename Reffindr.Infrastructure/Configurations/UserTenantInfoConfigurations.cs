using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models.User;

namespace Reffindr.Infrastructure.Configurations;

public class UserTenantInfoConfigurations : EntityTypeBaseConfiguration<UserTenantInfo>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<UserTenantInfo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User).WithOne(x => x.UserTenantInfo).HasForeignKey<UserTenantInfo>(x => x.UserId);
    }

    protected override void ConfigurateProperties(EntityTypeBuilder<UserTenantInfo> builder)
    {
        builder.Property(x => x.IsWorking)
            .IsRequired();

        builder.Property(x => x.HasWarranty)
         .IsRequired();

        builder.Property(x => x.RangeSalary)
         .IsRequired()
         .HasPrecision(18,2);
    }

    protected override void ConfigurateTableName(EntityTypeBuilder<UserTenantInfo> builder)
    {
        builder.ToTable("UsersTenantsInfo");
    }
}
