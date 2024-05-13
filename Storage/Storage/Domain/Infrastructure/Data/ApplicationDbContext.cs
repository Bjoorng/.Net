using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using Storage.Domain.Models;

namespace Storage.Domain.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}

