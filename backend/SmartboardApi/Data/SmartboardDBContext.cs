using Microsoft.EntityFrameworkCore;
using SmartboardApi.Models;
using SmartboardApi.Models.ProjectModule;
using System.Reflection.Metadata;

namespace SmartboardApi.Data;

public class SmartboardDBContext : DbContext
{
    public SmartboardDBContext(DbContextOptions<SmartboardDBContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(e => e.Projects)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .HasPrincipalKey(e => e.Id);
    }
}