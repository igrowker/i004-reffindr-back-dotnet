using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models.User;

namespace Reffindr.Infrastructure.Configurations;

public class UserConfigurations : EntityTypeBaseConfiguration<User>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId);
    }

    protected override void ConfigurateProperties(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(200);

    }

    protected override void ConfigurateTableName(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
    }
}
