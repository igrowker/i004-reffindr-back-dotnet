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

        builder.HasMany(x => x.User)
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
			new State { StateName = "Buenos Aires", CountryId = 1 },
			new State { StateName = "Catamarca", CountryId = 1 },
			new State { StateName = "Chaco", CountryId = 1 },
			new State { StateName = "Chubut", CountryId = 1 },
			new State { StateName = "Córdoba", CountryId = 1 },
			new State { StateName = "Corrientes", CountryId = 1 },
			new State { StateName = "Entre Ríos", CountryId = 1 },
			new State { StateName = "Formosa", CountryId = 1 },
			new State { StateName = "Jujuy", CountryId = 1 },
			new State { StateName = "La Pampa", CountryId = 1 },
			new State { StateName = "La Rioja", CountryId = 1 },
			new State { StateName = "Mendoza", CountryId = 1 },
			new State { StateName = "Misiones", CountryId = 1 },
			new State { StateName = "Neuquén", CountryId = 1 },
			new State { StateName = "Río Negro", CountryId = 1 },
			new State { StateName = "Salta", CountryId = 1 },
			new State { StateName = "San Juan", CountryId = 1 },
			new State { StateName = "San Luis", CountryId = 1 },
			new State { StateName = "Santa Cruz", CountryId = 1 },
			new State { StateName = "Santa Fe", CountryId = 1 },
			new State { StateName = "Santiago del Estero", CountryId = 1 },
			new State { StateName = "Tierra del Fuego", CountryId = 1 },
			new State { StateName = "Tucumán", CountryId = 1 },
			new State { StateName = "Ciudad Autónoma de Buenos Aires", CountryId = 1 }
		);
	}
}
