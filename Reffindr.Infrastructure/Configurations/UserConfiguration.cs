using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Infrastructure.Configurations;

public class UserConfiguration : EntityTypeBaseConfiguration<User>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleId);

        builder.HasOne(x => x.Country)
            .WithMany(x => x.User)
            .HasForeignKey(x => x.CountryId);

        builder.HasOne(x => x.State)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.StateId);

        builder.HasMany(x => x.Applications)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.UserOwnerInfo)
            .WithOne(x => x.User)
            .HasForeignKey<User>(x => x.UserOwnerInfoId);

        builder.HasOne(x => x.UserTenantInfo)
            .WithOne(x => x.User)
            .HasForeignKey<User>(x => x.UserTenantInfoId);

        builder.HasOne(x => x.Image)
            .WithOne(x => x.User)
            .HasForeignKey<Image>(x => x.UserId);

        builder.HasOne(x => x.Genre)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.GenreId);
      
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
