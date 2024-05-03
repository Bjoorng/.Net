using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext{

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=productManager;Trusted_Connection=True"));
    }

}