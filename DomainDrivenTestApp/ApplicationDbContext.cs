using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options){

    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

}