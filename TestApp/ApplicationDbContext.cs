using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext{

    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testManager;Trusted_Connection=True"));
    }
}