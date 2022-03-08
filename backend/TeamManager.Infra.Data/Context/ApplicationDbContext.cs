using Microsoft.EntityFrameworkCore;
using TeamManager.Domain.Entities;

namespace TeamManager.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<TeamMember> TeamMember { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Contractor> Contractor { get; set; }
    public DbSet<Employee> Employee { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Contractor>().ToTable("Contractor");
        builder.Entity<Employee>().ToTable("Employee");
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}