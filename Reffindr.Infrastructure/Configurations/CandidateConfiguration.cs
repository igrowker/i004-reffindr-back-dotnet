using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models;

namespace Reffindr.Infrastructure.Configurations
{
    public class CandidateConfiguration : EntityTypeBaseConfiguration<Candidate>
    {
        protected override void ConfigurateConstraints(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Application)
                .WithOne(x => x.Candidate)
                .HasForeignKey<Candidate>(x => x.ApplicationId);
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<Candidate> builder)
        {
            builder.Property(x => x.SelectedByTenant)
                .IsRequired();
        }

        protected override void ConfigurateTableName(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("Candidates");
        }
    }
}
