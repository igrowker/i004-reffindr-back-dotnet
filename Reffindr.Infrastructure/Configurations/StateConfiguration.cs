using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models;

namespace Reffindr.Infrastructure.Configurations;

public class StateConfiguration : EntityTypeBaseConfiguration<State>
{
	protected override void ConfigurateConstraints(EntityTypeBuilder<State> builder)
	{
		builder.HasKey(x => x.Id);

		builder.HasOne(x => x.Country)
				.WithMany(x => x.State)
				.HasForeignKey(x => x.CountryId);

		builder.HasMany(x => x.Property)
			.WithOne(x => x.State)
			.HasForeignKey(x => x.StateId);

        builder.HasMany(x => x.Users)
            .WithOne(x => x.State)
            .HasForeignKey(x => x.StateId);
    }

	protected override void ConfigurateProperties(EntityTypeBuilder<State> builder)
	{
		builder.Property(x => x.StateName)
			.IsRequired()
			.HasMaxLength(100);
	}

	protected override void ConfigurateTableName(EntityTypeBuilder<State> builder)
	{
		builder.ToTable("States");
	}
    protected override void SeedData(EntityTypeBuilder<State> builder)
    {
        builder.HasData(
            new State { Id = 1, StateName = "Buenos Aires", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 2, StateName = "Catamarca", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 3, StateName = "Chaco", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 4, StateName = "Chubut", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 5, StateName = "Córdoba", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 6, StateName = "Corrientes", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 7, StateName = "Entre Ríos", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 8, StateName = "Formosa", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 9, StateName = "Jujuy", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 10, StateName = "La Pampa", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 11, StateName = "La Rioja", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 12, StateName = "Mendoza", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 13, StateName = "Misiones", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 14, StateName = "Neuquén", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 15, StateName = "Río Negro", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 16, StateName = "Salta", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 17, StateName = "San Juan", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 18, StateName = "San Luis", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 19, StateName = "Santa Cruz", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 20, StateName = "Santa Fe", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 21, StateName = "Santiago del Estero", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 22, StateName = "Tierra del Fuego", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 23, StateName = "Tucumán", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false },
            new State { Id = 24, StateName = "Ciudad Autónoma de Buenos Aires", CountryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, IsDeleted = false }
        );
    }
}
