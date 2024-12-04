using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models;

namespace Reffindr.Infrastructure.Configurations
{
    public class FavoriteConfiguration : EntityTypeBaseConfiguration<Favorite>
    {
        protected override void ConfigurateConstraints(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(fp => fp.User)
                .WithMany(u => u.FavoriteProperties)
                .HasForeignKey(fp => fp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(fp => fp.Property)
                .WithMany(p => p.FavoriteByUsers)
                .HasForeignKey(fp => fp.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<Favorite> builder)
        {
            builder.Property(x => x.PropertyId)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();
        }

        protected override void ConfigurateTableName(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorites");
        }
    }
}
