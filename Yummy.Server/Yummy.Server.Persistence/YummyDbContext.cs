using Microsoft.EntityFrameworkCore;
using Yummy.Server.Application.Interfaces;
using Yummy.Server.Domain;
using Yummy.Server.Persistence.EntityTypeConfigurations;

namespace Yummy.Server.Persistence;

public class YummyDbContext : DbContext, IYummyDbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Dish> Dishes { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public YummyDbContext(DbContextOptions<YummyDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new DishConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}