using Microsoft.EntityFrameworkCore;

namespace SmartboardApi.Models;

public class SmartboardDBContext : DbContext
{
    public SmartboardDBContext(DbContextOptions<SmartboardDBContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
}