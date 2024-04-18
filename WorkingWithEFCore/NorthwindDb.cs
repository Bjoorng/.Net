using Microsoft.EntityFrameworkCore;

namespace Northwind.EntityModels;

public class NorthwindDb : DbContext
{

    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string databaseFile = "Northwind.db";
        string path = Path.Combine(Environment.CurrentDirectory, databaseFile);
        string connectionString = $"Data Source={path}";
        WriteLine(connectionString);
        optionsBuilder.UseSqlite(connectionString);
        optionsBuilder.LogTo(WriteLine) // This is the Console method.
        #if DEBUG
            .EnableSensitiveDataLogging() // Include SQL parameters.
            .EnableDetailedErrors()
        #endif
        ;
    }

    protected override void OnModelCreating(
    ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
        .Property(category => category.CategoryName)
        .IsRequired() // NOT NULL
        .HasMaxLength(15);
        if (Database.ProviderName?.Contains("Sqlite") ?? false)
        {
            modelBuilder.Entity<Product>()
            .Property(product => product.Cost)
            .HasConversion<double>();
        }
    }
}