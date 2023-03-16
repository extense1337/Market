using Market.DomainEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Market.Database;

public sealed class MarketDbContext : DbContext
{
    public MarketDbContext(DbContextOptions<MarketDbContext> options) 
        : base(options) { }
    
    public DbSet<Person> Persons { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<Type>().ToTable("TableName");
    }
    
    // How to do migrations after schema change
    //
    // Install ef tool if havent
    // cmd > dotnet tool install --global dotnet-ef --version 6.*
    //
    // Create migration
    // cmd> cd Market.Database
    // cmd> dotnet ef --startup-project ../Market.WebApi migrations add <migration-name>
    // cmd> dotnet ef --startup-project ../Market.WebApi database update
}