using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext{

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Subject> Subjects => Set<Subject>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=schoolProjectDb;Trusted_Connection=True"));
    }

}