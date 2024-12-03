﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reffindr.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenreName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsWorking = table.Column<bool>(type: "boolean", nullable: false),
                    HasWarranty = table.Column<bool>(type: "boolean", nullable: false),
                    RangeSalary = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SalaryName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StateName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: false),
                    RequirementId = table.Column<int>(type: "integer", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Environments = table.Column<int>(type: "integer", nullable: false),
                    Bathrooms = table.Column<int>(type: "integer", nullable: false),
                    Bedrooms = table.Column<int>(type: "integer", nullable: false),
                    Seniority = table.Column<int>(type: "integer", nullable: false),
                    Water = table.Column<bool>(type: "boolean", nullable: false),
                    Gas = table.Column<bool>(type: "boolean", nullable: false),
                    Surveillance = table.Column<bool>(type: "boolean", nullable: false),
                    Electricity = table.Column<bool>(type: "boolean", nullable: false),
                    Internet = table.Column<bool>(type: "boolean", nullable: false),
                    Pool = table.Column<bool>(type: "boolean", nullable: false),
                    Garage = table.Column<bool>(type: "boolean", nullable: false),
                    Pets = table.Column<bool>(type: "boolean", nullable: false),
                    Grill = table.Column<bool>(type: "boolean", nullable: false),
                    Elevator = table.Column<bool>(type: "boolean", nullable: false),
                    Terrace = table.Column<bool>(type: "boolean", nullable: false),
                    IsHistoric = table.Column<bool>(type: "boolean", nullable: false),
                    NotificationId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Requirements_RequirementId",
                        column: x => x.RequirementId,
                        principalTable: "Requirements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Properties_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    StateId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Dni = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    IsProfileComplete = table.Column<bool>(type: "boolean", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: true),
                    UserOwnerInfoId = table.Column<int>(type: "integer", nullable: true),
                    UserTenantInfoId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PropertyId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PropertyId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    ImageUrl = table.Column<List<string>>(type: "text[]", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserReceivingId = table.Column<int>(type: "integer", nullable: true),
                    Message = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Type = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    PropertyId = table.Column<int>(type: "integer", nullable: false),
                    Read = table.Column<bool>(type: "boolean", nullable: false),
                    UserSenderId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserReceivingId",
                        column: x => x.UserReceivingId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    RatedUserId = table.Column<int>(type: "integer", nullable: false),
                    RatingValue = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_RatedByUserId",
                        column: x => x.RatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_RatedUserId",
                        column: x => x.RatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersOwnersInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsCompany = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersOwnersInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersOwnersInfo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersTenantsInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsWorking = table.Column<bool>(type: "boolean", nullable: false),
                    HasWarranty = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    SalaryId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTenantsInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersTenantsInfo_Salaries_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "Salaries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersTenantsInfo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationId = table.Column<int>(type: "integer", nullable: false),
                    SelectedByTenant = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryName", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[] { 1, "Argentina", new DateTime(2024, 12, 3, 23, 47, 12, 684, DateTimeKind.Utc).AddTicks(3971), false, null });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "GenreName", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 3, 23, 47, 12, 684, DateTimeKind.Utc).AddTicks(6411), "Male", false, null },
                    { 2, new DateTime(2024, 12, 3, 23, 47, 12, 684, DateTimeKind.Utc).AddTicks(6413), "Female", false, null },
                    { 3, new DateTime(2024, 12, 3, 23, 47, 12, 684, DateTimeKind.Utc).AddTicks(6414), "Non-binary", false, null },
                    { 4, new DateTime(2024, 12, 3, 23, 47, 12, 684, DateTimeKind.Utc).AddTicks(6415), "Gender fluid", false, null },
                    { 5, new DateTime(2024, 12, 3, 23, 47, 12, 684, DateTimeKind.Utc).AddTicks(6416), "Agender", false, null },
                    { 6, new DateTime(2024, 12, 3, 23, 47, 12, 684, DateTimeKind.Utc).AddTicks(6417), "Bigender", false, null },
                    { 7, new DateTime(2024, 12, 3, 23, 47, 12, 684, DateTimeKind.Utc).AddTicks(6418), "Demiboy", false, null },
                    { 8, new DateTime(2024, 12, 3, 23, 47, 12, 684, DateTimeKind.Utc).AddTicks(6419), "DemiGirl", false, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "RoleName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 3, 23, 47, 12, 689, DateTimeKind.Utc).AddTicks(9733), false, "Tenant", null },
                    { 2, new DateTime(2024, 12, 3, 23, 47, 12, 689, DateTimeKind.Utc).AddTicks(9735), false, "Owner", null }
                });

            migrationBuilder.InsertData(
                table: "Salaries",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "SalaryName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(1896), false, "300.000 - 600.000", null },
                    { 2, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(1898), false, "600.000 - 1.000.000", null },
                    { 3, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(1900), false, "1.000.000 - 3.000.000", null },
                    { 4, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(1901), false, "3.000.000 +", null }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CountryId", "CreatedAt", "IsDeleted", "StateName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5491), false, "Buenos Aires", null },
                    { 2, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5493), false, "Catamarca", null },
                    { 3, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5495), false, "Chaco", null },
                    { 4, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5496), false, "Chubut", null },
                    { 5, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5497), false, "Córdoba", null },
                    { 6, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5499), false, "Corrientes", null },
                    { 7, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5500), false, "Entre Ríos", null },
                    { 8, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5501), false, "Formosa", null },
                    { 9, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5502), false, "Jujuy", null },
                    { 10, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5503), false, "La Pampa", null },
                    { 11, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5505), false, "La Rioja", null },
                    { 12, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5506), false, "Mendoza", null },
                    { 13, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5507), false, "Misiones", null },
                    { 14, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5508), false, "Neuquén", null },
                    { 15, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5509), false, "Río Negro", null },
                    { 16, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5511), false, "Salta", null },
                    { 17, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5512), false, "San Juan", null },
                    { 18, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5513), false, "San Luis", null },
                    { 19, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5514), false, "Santa Cruz", null },
                    { 20, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5515), false, "Santa Fe", null },
                    { 21, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5516), false, "Santiago del Estero", null },
                    { 22, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5518), false, "Tierra del Fuego", null },
                    { 23, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5519), false, "Tucumán", null },
                    { 24, 1, new DateTime(2024, 12, 3, 23, 47, 12, 690, DateTimeKind.Utc).AddTicks(5521), false, "Ciudad Autónoma de Buenos Aires", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_PropertyId",
                table: "Applications",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ApplicationId",
                table: "Candidates",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_PropertyId",
                table: "Images",
                column: "PropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_PropertyId",
                table: "Notifications",
                column: "PropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserReceivingId",
                table: "Notifications",
                column: "UserReceivingId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CountryId",
                table: "Properties",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_RequirementId",
                table: "Properties",
                column: "RequirementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_StateId",
                table: "Properties",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RatedByUserId",
                table: "Ratings",
                column: "RatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RatedUserId",
                table: "Ratings",
                column: "RatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenreId",
                table: "Users",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StateId",
                table: "Users",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersOwnersInfo_UserId",
                table: "UsersOwnersInfo",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersTenantsInfo_SalaryId",
                table: "UsersTenantsInfo",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersTenantsInfo_UserId",
                table: "UsersTenantsInfo",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "UsersOwnersInfo");

            migrationBuilder.DropTable(
                name: "UsersTenantsInfo");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
