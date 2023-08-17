using System.Runtime;
using firstDiscord.Net.Model;
using Microsoft.EntityFrameworkCore;

namespace firstDiscord.Net.Data;

public class AppDbContext : DbContext
{
    public DbSet<TeleportChannel> TeleportChannels { set; get; }
    
    public DbSet<WayPoint> WayPoints { get; set; }
    public DbSet<WayPointCategory> WayPointCategories { get; set; }

    public DbSet<WebBookmark> WebBookmarks { get; set; }
    public DbSet<WebCategory> WebCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source=harukin.db");
    }
}