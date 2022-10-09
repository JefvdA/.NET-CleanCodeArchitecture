using Microsoft.EntityFrameworkCore;

using Domain.Models;
using Infrastructure.Seeding;

namespace Infrastructure.Contexts;

public class CleanCodeArchitectureDbContext : DbContext
{
    public CleanCodeArchitectureDbContext(DbContextOptions<CleanCodeArchitectureDbContext> options) : base(options)
    {
    }
    
    public DbSet<TodoItem>? TodoItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanCodeArchitectureDbContext).Assembly);
        
        modelBuilder.Entity<TodoItem>().Seed();
    }
}