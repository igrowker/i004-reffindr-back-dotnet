using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Infrastructure.Configurations;

public class GenreConfiguration : EntityTypeBaseConfiguration<Genre>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Users).WithOne(x => x.Genre).HasForeignKey(x => x.GenreId);
    }

    protected override void ConfigurateProperties(EntityTypeBuilder<Genre> builder)
    {
        builder.Property(x => x.GenreName)
            .IsRequired()
            .HasMaxLength(100);
    }

    protected override void ConfigurateTableName(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("Genres");
    }

    protected override void SeedData(EntityTypeBuilder<Genre> builder)
    {
        builder.HasData(
            new Genre
            {
                Id = 1,
                GenreName = "Male",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
                IsDeleted = false
            },
            new Genre
            {
                Id = 2,
                GenreName = "Female",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
                IsDeleted = false
            },
            new Genre
            {
                    Id = 3,
                    GenreName = "Non-binary",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = null,
                    IsDeleted = false
            },
            new Genre
            {
                    Id = 4,
                    GenreName = "Gender fluid",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = null,
                    IsDeleted = false
            },
        new Genre
            {
                Id = 5,
                GenreName = "Agender",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
                IsDeleted = false
            },
        new Genre
            {
                Id = 6,
                GenreName = "Bigender",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
                IsDeleted = false
            },
        new Genre
            {
                Id = 7,
                GenreName = "Demiboy",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
                IsDeleted = false
            },
        new Genre
            {
                Id = 8,
                GenreName = "DemiGirl",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
                IsDeleted = false
            }
            );
    }

}
