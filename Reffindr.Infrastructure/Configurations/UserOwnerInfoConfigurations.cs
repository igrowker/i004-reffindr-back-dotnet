using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models.User;

namespace Reffindr.Infrastructure.Configurations;

public class UserOwnerInfoConfigurations : EntityTypeBaseConfiguration<UserOwnerInfo>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<UserOwnerInfo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User).WithOne(x => x.UserOwnerInfo).HasForeignKey<UserOwnerInfo>(x => x.UserId);
    }

    protected override void ConfigurateProperties(EntityTypeBuilder<UserOwnerInfo> builder)
    {
        builder.Property(x => x.IsCompany)
            .IsRequired();
    }

    protected override void ConfigurateTableName(EntityTypeBuilder<UserOwnerInfo> builder)
    {
        builder.ToTable("UsersOwnersInfo");
    }
}
