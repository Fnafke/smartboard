using Microsoft.EntityFrameworkCore;
using SmartboardApi.Models;

namespace SmartboardApi.Data;

public class SmartboardDBContext : DbContext
{
    public SmartboardDBContext(DbContextOptions<SmartboardDBContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}