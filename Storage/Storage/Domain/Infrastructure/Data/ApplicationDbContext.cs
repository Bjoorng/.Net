using Microsoft.EntityFrameworkCore;
using Storage.Domain.Models;

namespace Storage.Domain.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}

