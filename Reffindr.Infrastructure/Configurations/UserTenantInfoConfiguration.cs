using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Infrastructure.Configurations;

public class UserTenantInfoConfiguration : EntityTypeBaseConfiguration<UserTenantInfo>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<UserTenantInfo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User).WithOne(x => x.UserTenantInfo).HasForeignKey<UserTenantInfo>(x => x.UserId);

        builder.HasOne(x => x.Salary)
            .WithMany(x => x.UsersTenantInfo)
            .HasForeignKey(x => x.SalaryId);
    }

    protected override void ConfigurateProperties(EntityTypeBuilder<UserTenantInfo> builder)
    {
        builder.Property(x => x.IsWorking)
            .IsRequired();

        builder.Property(x => x.HasWarranty)
         .IsRequired();

       
    }

    protected override void ConfigurateTableName(EntityTypeBuilder<UserTenantInfo> builder)
    {
        builder.ToTable("UsersTenantsInfo");
    }
}
