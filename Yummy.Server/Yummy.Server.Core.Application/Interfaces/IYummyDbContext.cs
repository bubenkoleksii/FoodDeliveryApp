using Microsoft.EntityFrameworkCore;
using Yummy.Server.Domain;

namespace Yummy.Server.Application.Interfaces;

public interface IYummyDbContext
{
    DbSet<Category> Categories { get; set; }

    DbSet<Dish> Dishes { get; set; }

    DbSet<Order> Orders { get; set; }

    DbSet<OrderItem> OrderItems { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}