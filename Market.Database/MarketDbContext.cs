using Microsoft.EntityFrameworkCore;

namespace Market.Database;

public class MarketDbContext : DbContext
{
    public MarketDbContext(DbContextOptions<MarketDbContext> options) 
        : base(options) { }
    
    // public DbSet<Type> Property { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<Type>().ToTable("TableName");
    }
}