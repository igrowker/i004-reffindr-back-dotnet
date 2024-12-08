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
    public DbSet<UserOwnerInfo> UsersOwnersInfo { get; set; }
    public DbSet<UserTenantInfo> UsersTenantsInfo { get; set; }
    public DbSet<ApplicationModel> Applications { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Requirement> Requirements { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Salary> Salaries { get; set; }

    public DbSet<Favorite> Favorites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("ReffindrDBSchema");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
