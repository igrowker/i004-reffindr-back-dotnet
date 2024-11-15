using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models;

namespace Reffindr.Infrastructure.Configurations
{
    public class RatingConfiguration : EntityTypeBaseConfiguration<Rating>
    {
        protected override void ConfigurateConstraints(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.RatedBy)
                .WithMany(x => x.RatingsGiven)
                .HasForeignKey(x => x.RatedByUserId);

            builder.HasOne(x => x.RatedUser)
                .WithMany(x => x.RatingsReceived)
                .HasForeignKey(x => x.RatedUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<Rating> builder)
        {
            builder.Property(x => x.RatingValue)
                .IsRequired();

            builder.Property(x => x.Comment)
                .HasMaxLength(1000);
        }

        protected override void ConfigurateTableName(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Ratings");
        }
    }
}
