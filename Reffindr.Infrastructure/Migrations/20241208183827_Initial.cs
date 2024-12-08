using System;
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
            migrationBuilder.EnsureSchema(
                name: "ReffindrDBSchema");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "ReffindrDBSchema",
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
                schema: "ReffindrDBSchema",
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
                schema: "ReffindrDBSchema",
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
                schema: "ReffindrDBSchema",
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
                schema: "ReffindrDBSchema",
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
                schema: "ReffindrDBSchema",
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
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                schema: "ReffindrDBSchema",
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
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Requirements_RequirementId",
                        column: x => x.RequirementId,
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Requirements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Properties_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "ReffindrDBSchema",
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
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Genres_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Genres",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                schema: "ReffindrDBSchema",
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
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                schema: "ReffindrDBSchema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PropertyId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                schema: "ReffindrDBSchema",
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
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Properties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                schema: "ReffindrDBSchema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserSender = table.Column<int>(type: "integer", nullable: true),
                    UserReceiver = table.Column<int>(type: "integer", nullable: true),
                    Type = table.Column<int>(type: "integer", maxLength: 15, nullable: false),
                    Message = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    PropertyId = table.Column<int>(type: "integer", nullable: true),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
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
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Properties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                schema: "ReffindrDBSchema",
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
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_RatedUserId",
                        column: x => x.RatedUserId,
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersOwnersInfo",
                schema: "ReffindrDBSchema",
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
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersTenantsInfo",
                schema: "ReffindrDBSchema",
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
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Salaries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersTenantsInfo_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                schema: "ReffindrDBSchema",
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
                        principalSchema: "ReffindrDBSchema",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "ReffindrDBSchema",
                table: "Countries",
                columns: new[] { "Id", "CountryName", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[] { 1, "Argentina", new DateTime(2024, 12, 8, 18, 38, 26, 642, DateTimeKind.Utc).AddTicks(337), false, null });

            migrationBuilder.InsertData(
                schema: "ReffindrDBSchema",
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "GenreName", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 8, 18, 38, 26, 642, DateTimeKind.Utc).AddTicks(6950), "Male", false, null },
                    { 2, new DateTime(2024, 12, 8, 18, 38, 26, 642, DateTimeKind.Utc).AddTicks(6953), "Female", false, null },
                    { 3, new DateTime(2024, 12, 8, 18, 38, 26, 642, DateTimeKind.Utc).AddTicks(6955), "Non-binary", false, null },
                    { 4, new DateTime(2024, 12, 8, 18, 38, 26, 642, DateTimeKind.Utc).AddTicks(6956), "Gender fluid", false, null },
                    { 5, new DateTime(2024, 12, 8, 18, 38, 26, 642, DateTimeKind.Utc).AddTicks(6957), "Agender", false, null },
                    { 6, new DateTime(2024, 12, 8, 18, 38, 26, 642, DateTimeKind.Utc).AddTicks(6958), "Bigender", false, null },
                    { 7, new DateTime(2024, 12, 8, 18, 38, 26, 642, DateTimeKind.Utc).AddTicks(6959), "Demiboy", false, null },
                    { 8, new DateTime(2024, 12, 8, 18, 38, 26, 642, DateTimeKind.Utc).AddTicks(6960), "DemiGirl", false, null }
                });

            migrationBuilder.InsertData(
                schema: "ReffindrDBSchema",
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "RoleName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 8, 18, 38, 26, 647, DateTimeKind.Utc).AddTicks(5854), false, "Tenant", null },
                    { 2, new DateTime(2024, 12, 8, 18, 38, 26, 647, DateTimeKind.Utc).AddTicks(5857), false, "Owner", null }
                });

            migrationBuilder.InsertData(
                schema: "ReffindrDBSchema",
                table: "Salaries",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "SalaryName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 8, 18, 38, 26, 647, DateTimeKind.Utc).AddTicks(8018), false, "300.000 - 600.000", null },
                    { 2, new DateTime(2024, 12, 8, 18, 38, 26, 647, DateTimeKind.Utc).AddTicks(8044), false, "600.000 - 1.000.000", null },
                    { 3, new DateTime(2024, 12, 8, 18, 38, 26, 647, DateTimeKind.Utc).AddTicks(8045), false, "1.000.000 - 3.000.000", null },
                    { 4, new DateTime(2024, 12, 8, 18, 38, 26, 647, DateTimeKind.Utc).AddTicks(8047), false, "3.000.000 +", null }
                });

            migrationBuilder.InsertData(
                schema: "ReffindrDBSchema",
                table: "States",
                columns: new[] { "Id", "CountryId", "CreatedAt", "IsDeleted", "StateName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1091), false, "Buenos Aires", null },
                    { 2, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1093), false, "Catamarca", null },
                    { 3, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1095), false, "Chaco", null },
                    { 4, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1096), false, "Chubut", null },
                    { 5, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1097), false, "Córdoba", null },
                    { 6, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1098), false, "Corrientes", null },
                    { 7, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1099), false, "Entre Ríos", null },
                    { 8, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1101), false, "Formosa", null },
                    { 9, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1102), false, "Jujuy", null },
                    { 10, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1103), false, "La Pampa", null },
                    { 11, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1104), false, "La Rioja", null },
                    { 12, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1137), false, "Mendoza", null },
                    { 13, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1139), false, "Misiones", null },
                    { 14, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1140), false, "Neuquén", null },
                    { 15, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1141), false, "Río Negro", null },
                    { 16, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1142), false, "Salta", null },
                    { 17, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1143), false, "San Juan", null },
                    { 18, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1145), false, "San Luis", null },
                    { 19, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1146), false, "Santa Cruz", null },
                    { 20, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1147), false, "Santa Fe", null },
                    { 21, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1148), false, "Santiago del Estero", null },
                    { 22, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1149), false, "Tierra del Fuego", null },
                    { 23, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1150), false, "Tucumán", null },
                    { 24, 1, new DateTime(2024, 12, 8, 18, 38, 26, 648, DateTimeKind.Utc).AddTicks(1151), false, "Ciudad Autónoma de Buenos Aires", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_PropertyId",
                schema: "ReffindrDBSchema",
                table: "Applications",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                schema: "ReffindrDBSchema",
                table: "Applications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ApplicationId",
                schema: "ReffindrDBSchema",
                table: "Candidates",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_PropertyId",
                schema: "ReffindrDBSchema",
                table: "Favorites",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                schema: "ReffindrDBSchema",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PropertyId",
                schema: "ReffindrDBSchema",
                table: "Images",
                column: "PropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                schema: "ReffindrDBSchema",
                table: "Images",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_PropertyId",
                schema: "ReffindrDBSchema",
                table: "Notifications",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                schema: "ReffindrDBSchema",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CountryId",
                schema: "ReffindrDBSchema",
                table: "Properties",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_RequirementId",
                schema: "ReffindrDBSchema",
                table: "Properties",
                column: "RequirementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_StateId",
                schema: "ReffindrDBSchema",
                table: "Properties",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RatedByUserId",
                schema: "ReffindrDBSchema",
                table: "Ratings",
                column: "RatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RatedUserId",
                schema: "ReffindrDBSchema",
                table: "Ratings",
                column: "RatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                schema: "ReffindrDBSchema",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                schema: "ReffindrDBSchema",
                table: "Users",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenreId",
                schema: "ReffindrDBSchema",
                table: "Users",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "ReffindrDBSchema",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StateId",
                schema: "ReffindrDBSchema",
                table: "Users",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersOwnersInfo_UserId",
                schema: "ReffindrDBSchema",
                table: "UsersOwnersInfo",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersTenantsInfo_SalaryId",
                schema: "ReffindrDBSchema",
                table: "UsersTenantsInfo",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersTenantsInfo_UserId",
                schema: "ReffindrDBSchema",
                table: "UsersTenantsInfo",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates",
                schema: "ReffindrDBSchema");

            migrationBuilder.DropTable(
                name: "Favorites",
                schema: "ReffindrDBSchema");

            migrationBuilder.DropTable(
                name: "Images",
                schema: "ReffindrDBSchema");

            migrationBuilder.DropTable(
                name: "Notifications",
                schema: "ReffindrDBSchema");

            migrationBuilder.DropTable(
                name: "Ratings",
                schema: "ReffindrDBSchema");

            migrationBuilder.DropTable(
                name: "UsersOwnersInfo",
                schema: "ReffindrDBSchema");

            migrationBuilder.DropTable(
                name: "UsersTenantsInfo",
                schema: "ReffindrDBSchema");

            migrationBuilder.DropTable(
                name: "Applications",
                schema: "ReffindrDBSchema");

            migrationBuilder.DropTable(
                name: "Salaries",
                schema: "ReffindrDBSchema");

            migrationBuilder.DropTable(
                name: "Properties",
                schema: "ReffindrDBSchema");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "ReffindrDBSchema");

            migrationBuilder.DropTable(
                name: "Requirements",
                schema: "ReffindrDBSchema");

            migrationBuilder.DropTable(
                name: "Genres",
                schema: "ReffindrDBSchema");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "ReffindrDBSchema");

            migrationBuilder.DropTable(
                name: "States",
                schema: "ReffindrDBSchema");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "ReffindrDBSchema");
        }
    }
}
