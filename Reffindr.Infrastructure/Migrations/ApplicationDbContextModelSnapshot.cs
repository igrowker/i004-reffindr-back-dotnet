﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Reffindr.Infrastructure.Data;

#nullable disable

namespace Reffindr.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Reffindr.Domain.Models.ApplicationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("PropertyId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("UserId");

                    b.ToTable("Applications", (string)null);
                });

            modelBuilder.Entity("Reffindr.Domain.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("SelectedByTenant")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId")
                        .IsUnique();

                    b.ToTable("Candidates", (string)null);
                });

            modelBuilder.Entity("Reffindr.Domain.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Countries", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryName = "Argentina",
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 440, DateTimeKind.Utc).AddTicks(4593),
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("Reffindr.Domain.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("PropertyId")
                        .HasColumnType("integer");

                    b.Property<bool>("Read")
                        .HasColumnType("boolean");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UserReceivingId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserSenderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId")
                        .IsUnique();

                    b.HasIndex("UserReceivingId");

                    b.ToTable("Notifications", (string)null);
                });

            modelBuilder.Entity("Reffindr.Domain.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("Bathrooms")
                        .HasColumnType("integer");

                    b.Property<int>("Bedrooms")
                        .HasColumnType("integer");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<bool>("Electricity")
                        .HasColumnType("boolean");

                    b.Property<bool>("Elevator")
                        .HasColumnType("boolean");

                    b.Property<int>("Environments")
                        .HasColumnType("integer");

                    b.Property<bool>("Garage")
                        .HasColumnType("boolean");

                    b.Property<bool>("Gas")
                        .HasColumnType("boolean");

                    b.Property<bool>("Grill")
                        .HasColumnType("boolean");

                    b.Property<bool>("Internet")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsHistoric")
                        .HasColumnType("boolean");

                    b.Property<int>("NotificationId")
                        .HasColumnType("integer");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<bool>("Pets")
                        .HasColumnType("boolean");

                    b.Property<bool>("Pool")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int?>("RequirementId")
                        .HasColumnType("integer");

                    b.Property<int>("Seniority")
                        .HasColumnType("integer");

                    b.Property<int>("StateId")
                        .HasColumnType("integer");

                    b.Property<bool>("Surveillance")
                        .HasColumnType("boolean");

                    b.Property<int>("TenantId")
                        .HasColumnType("integer");

                    b.Property<bool>("Terrace")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Water")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("RequirementId")
                        .IsUnique();

                    b.HasIndex("StateId");

                    b.ToTable("Properties", (string)null);
                });

            modelBuilder.Entity("Reffindr.Domain.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("RatedByUserId")
                        .HasColumnType("integer");

                    b.Property<int>("RatedUserId")
                        .HasColumnType("integer");

                    b.Property<int>("RatingValue")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("RatedByUserId");

                    b.HasIndex("RatedUserId");

                    b.ToTable("Ratings", (string)null);
                });

            modelBuilder.Entity("Reffindr.Domain.Models.Requirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("HasWarranty")
                        .IsRequired()
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsWorking")
                        .IsRequired()
                        .HasColumnType("boolean");

                    b.Property<decimal?>("RangeSalary")
                        .IsRequired()
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Requirements", (string)null);
                });

            modelBuilder.Entity("Reffindr.Domain.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("States", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6639),
                            IsDeleted = false,
                            StateName = "Buenos Aires"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6642),
                            IsDeleted = false,
                            StateName = "Catamarca"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6644),
                            IsDeleted = false,
                            StateName = "Chaco"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6645),
                            IsDeleted = false,
                            StateName = "Chubut"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6646),
                            IsDeleted = false,
                            StateName = "Córdoba"
                        },
                        new
                        {
                            Id = 6,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6648),
                            IsDeleted = false,
                            StateName = "Corrientes"
                        },
                        new
                        {
                            Id = 7,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6649),
                            IsDeleted = false,
                            StateName = "Entre Ríos"
                        },
                        new
                        {
                            Id = 8,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6650),
                            IsDeleted = false,
                            StateName = "Formosa"
                        },
                        new
                        {
                            Id = 9,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6652),
                            IsDeleted = false,
                            StateName = "Jujuy"
                        },
                        new
                        {
                            Id = 10,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6653),
                            IsDeleted = false,
                            StateName = "La Pampa"
                        },
                        new
                        {
                            Id = 11,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6654),
                            IsDeleted = false,
                            StateName = "La Rioja"
                        },
                        new
                        {
                            Id = 12,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6655),
                            IsDeleted = false,
                            StateName = "Mendoza"
                        },
                        new
                        {
                            Id = 13,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6657),
                            IsDeleted = false,
                            StateName = "Misiones"
                        },
                        new
                        {
                            Id = 14,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6658),
                            IsDeleted = false,
                            StateName = "Neuquén"
                        },
                        new
                        {
                            Id = 15,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6659),
                            IsDeleted = false,
                            StateName = "Río Negro"
                        },
                        new
                        {
                            Id = 16,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6660),
                            IsDeleted = false,
                            StateName = "Salta"
                        },
                        new
                        {
                            Id = 17,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6661),
                            IsDeleted = false,
                            StateName = "San Juan"
                        },
                        new
                        {
                            Id = 18,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6662),
                            IsDeleted = false,
                            StateName = "San Luis"
                        },
                        new
                        {
                            Id = 19,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6664),
                            IsDeleted = false,
                            StateName = "Santa Cruz"
                        },
                        new
                        {
                            Id = 20,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6665),
                            IsDeleted = false,
                            StateName = "Santa Fe"
                        },
                        new
                        {
                            Id = 21,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6666),
                            IsDeleted = false,
                            StateName = "Santiago del Estero"
                        },
                        new
                        {
                            Id = 22,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6667),
                            IsDeleted = false,
                            StateName = "Tierra del Fuego"
                        },
                        new
                        {
                            Id = 23,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6668),
                            IsDeleted = false,
                            StateName = "Tucumán"
                        },
                        new
                        {
                            Id = 24,
                            CountryId = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(6669),
                            IsDeleted = false,
                            StateName = "Ciudad Autónoma de Buenos Aires"
                        });
                });

            modelBuilder.Entity("Reffindr.Domain.Models.UserModels.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(4029),
                            IsDeleted = false,
                            RoleName = "Tenant"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 11, 26, 7, 44, 28, 444, DateTimeKind.Utc).AddTicks(4031),
                            IsDeleted = false,
                            RoleName = "Owner"
                        });
                });

            modelBuilder.Entity("Reffindr.Domain.Models.UserModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Dni")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsProfileComplete")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int?>("StateId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UserOwnerInfoId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserTenantInfoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("RoleId");

                    b.HasIndex("StateId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Reffindr.Domain.Models.UserModels.UserOwnerInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCompany")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UsersOwnersInfo", (string)null);
                });

            modelBuilder.Entity("Reffindr.Domain.Models.UserModels.UserTenantInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("HasWarranty")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsWorking")
                        .HasColumnType("boolean");

                    b.Property<decimal>("RangeSalary")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UsersTenantsInfo", (string)null);
                });

            modelBuilder.Entity("Reffindr.Domain.Models.ApplicationModel", b =>
                {
                    b.HasOne("Reffindr.Domain.Models.Property", "Property")
                        .WithMany("Application")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reffindr.Domain.Models.UserModels.User", "User")
                        .WithMany("Applications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Reffindr.Domain.Models.Candidate", b =>
                {
                    b.HasOne("Reffindr.Domain.Models.ApplicationModel", "Application")
                        .WithOne("Candidate")
                        .HasForeignKey("Reffindr.Domain.Models.Candidate", "ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("Reffindr.Domain.Models.Notification", b =>
                {
                    b.HasOne("Reffindr.Domain.Models.Property", "Property")
                        .WithOne("Notification")
                        .HasForeignKey("Reffindr.Domain.Models.Notification", "PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reffindr.Domain.Models.UserModels.User", "UserReceiving")
                        .WithMany("Notifications")
                        .HasForeignKey("UserReceivingId");

                    b.Navigation("Property");

                    b.Navigation("UserReceiving");
                });

            modelBuilder.Entity("Reffindr.Domain.Models.Property", b =>
                {
                    b.HasOne("Reffindr.Domain.Models.Country", "Country")
                        .WithMany("Property")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reffindr.Domain.Models.Requirement", "Requirement")
                        .WithOne("Property")
                        .HasForeignKey("Reffindr.Domain.Models.Property", "RequirementId");

                    b.HasOne("Reffindr.Domain.Models.State", "State")
                        .WithMany("Property")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Requirement");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Reffindr.Domain.Models.Rating", b =>
                {
                    b.HasOne("Reffindr.Domain.Models.UserModels.User", "RatedBy")
                        .WithMany("RatingsGiven")
                        .HasForeignKey("RatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reffindr.Domain.Models.UserModels.User", "RatedUser")
                        .WithMany("RatingsReceived")
                        .HasForeignKey("RatedUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RatedBy");

                    b.Navigation("RatedUser");
                });

            modelBuilder.Entity("Reffindr.Domain.Models.State", b =>
                {
                    b.HasOne("Reffindr.Domain.Models.Country", "Country")
                        .WithMany("State")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Reffindr.Domain.Models.UserModels.User", b =>
                {
                    b.HasOne("Reffindr.Domain.Models.Country", "Country")
                        .WithMany("User")
                        .HasForeignKey("CountryId");

                    b.HasOne("Reffindr.Domain.Models.UserModels.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reffindr.Domain.Models.State", "State")
                        .WithMany("Users")
                        .HasForeignKey("StateId");

                    b.Navigation("Country");

                    b.Navigation("Role");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Reffindr.Domain.Models.UserModels.UserOwnerInfo", b =>
                {
                    b.HasOne("Reffindr.Domain.Models.UserModels.User", "User")
                        .WithOne("UserOwnerInfo")
                        .HasForeignKey("Reffindr.Domain.Models.UserModels.UserOwnerInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Reffindr.Domain.Models.UserModels.UserTenantInfo", b =>
                {
                    b.HasOne("Reffindr.Domain.Models.UserModels.User", "User")
                        .WithOne("UserTenantInfo")
                        .HasForeignKey("Reffindr.Domain.Models.UserModels.UserTenantInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Reffindr.Domain.Models.ApplicationModel", b =>
                {
                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("Reffindr.Domain.Models.Country", b =>
                {
                    b.Navigation("Property");

                    b.Navigation("State");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Reffindr.Domain.Models.Property", b =>
                {
                    b.Navigation("Application");

                    b.Navigation("Notification");
                });

            modelBuilder.Entity("Reffindr.Domain.Models.Requirement", b =>
                {
                    b.Navigation("Property");
                });

            modelBuilder.Entity("Reffindr.Domain.Models.State", b =>
                {
                    b.Navigation("Property");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Reffindr.Domain.Models.UserModels.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Reffindr.Domain.Models.UserModels.User", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Notifications");

                    b.Navigation("RatingsGiven");

                    b.Navigation("RatingsReceived");

                    b.Navigation("UserOwnerInfo");

                    b.Navigation("UserTenantInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
