﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Infrastructure.Configurations;

public class SalaryConfiguration : EntityTypeBaseConfiguration<Salary>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<Salary> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Users).WithOne(x => x.Salary).HasForeignKey(x => x.SalaryId);
    }

    protected override void ConfigurateProperties(EntityTypeBuilder<Salary> builder)
    {
        builder.Property(x => x.SalaryName)
            .IsRequired()
            .HasMaxLength(100);
    }

    protected override void ConfigurateTableName(EntityTypeBuilder<Salary> builder)
    {
        builder.ToTable("Salaries");
    }

    protected override void SeedData(EntityTypeBuilder<Salary> builder)
    {
        builder.HasData(
            new Salary()
            {
                Id = 1,
                SalaryName = "0-1",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
                IsDeleted = false
            },
            new Salary()
            {
                Id = 2,
                SalaryName = "1-2",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
                IsDeleted = false
            },
            new Salary()
            {
                Id = 3,
                SalaryName = "2-3",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
                IsDeleted = false
            },
            new Salary()
            {
                Id = 4,
                SalaryName = "3-4",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
                IsDeleted = false
            }

        );
    }

}
