using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Infrastructure.Configurations;

public class RoleConfiguration : EntityTypeBaseConfiguration<Role>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Users).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
    }

    protected override void ConfigurateProperties(EntityTypeBuilder<Role> builder)
    {
        builder.Property(x => x.RoleName)
            .IsRequired()
            .HasMaxLength(100);
    }

    protected override void ConfigurateTableName(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
    }

    protected override void SeedData(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role
            {
                Id = 1,
                RoleName = "Tenant",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
                IsDeleted = false
            },
            new Role
            {
                Id = 2,
                RoleName = "Owner",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
                IsDeleted = false
            }
        );
    }

}
