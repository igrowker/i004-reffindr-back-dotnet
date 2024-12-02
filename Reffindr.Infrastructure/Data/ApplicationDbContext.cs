using Microsoft.EntityFrameworkCore;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using System.Reflection;

namespace Reffindr.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserOwnerInfo> userOwnerInfos { get; set; }
    public DbSet<UserTenantInfo> userTenantInfos { get; set; }
    public DbSet<ApplicationModel> applications { get; set; }
    public DbSet<Candidate> candidates { get; set; }
    public DbSet<Country> Country { get; set; }
    public DbSet<Notification> Notification { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Rating> ratings { get; set; }
    public DbSet<Requirement> Requirements { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Image> Images { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<User>().ToTable("Usuarios", schema: "auth");

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
