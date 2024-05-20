using FastEndpoints2.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastEndpoints2.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserModel> Users => Set<UserModel>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    }
}
