using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models;

namespace Reffindr.Infrastructure.Configurations
{
    public class NotificationConfiguration : EntityTypeBaseConfiguration<Notification>
    {
        protected override void ConfigurateConstraints(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Property)
                .WithOne()
                .HasForeignKey<Notification>(x => x.PropertyId);
		}

        protected override void ConfigurateProperties(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(x => x.Message)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(15);
        }

        protected override void ConfigurateTableName(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");
        }
    }
}
