using Yummy.Server.Application.Orders;

namespace Yummy.Server.Tests.Common;

public static class YummyDbContextFactory
{
    public static Guid FirstUserId = Guid.NewGuid();

    public static Guid SecondUserId = Guid.NewGuid();


    public static Guid CategoryIdForDelete = Guid.NewGuid();

    public static Guid CategoryIdForUpdate = Guid.NewGuid();

    public static Guid CategoryIdWithDishes = Guid.NewGuid();


    public static Guid DishIdForDelete = Guid.NewGuid();

    public static Guid DishIdForUpdate = Guid.NewGuid();

    
    public static Guid OrderIdForUpdate = Guid.NewGuid();
    

    public static YummyDbContext Create()
    {
        var options = new DbContextOptionsBuilder<YummyDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new YummyDbContext(options);
        context.Database.EnsureCreated();

        var categories = GetMockCategories();
        var dishes = GetMockDishes();
        var orders = GetMockOrders();

        context.Categories.AddRange(categories);
        context.Dishes.AddRange(dishes);
        context.Orders.AddRange(orders);

        context.SaveChanges();
        return context;
    }

    public static void Destroy(YummyDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }

    private static IEnumerable<Category> GetMockCategories()
    {
        var categories = new List<Category>
        {
            new()
            {
                Id = CategoryIdWithDishes,
                Name = "Pizzas",
                Description = "Description about delicious pizzas"
            },
            new()
            {
                Id = Guid.Parse("55C1CDA0-36A9-4A4D-9326-0B5F26E295CD"),
                Name = "Sushi"
            },
            new()
            {
                Id = CategoryIdForDelete,
                Name = "Drinks",
                Description = "The best lemonades and alcoholic drinks"
            },
            new()
            {
                Id = CategoryIdForUpdate,
                Name = "Salads"
            }
        };

        return categories;
    }

    private static IEnumerable<Dish> GetMockDishes()
    {
        var dishes = new List<Dish>
        {
            new()
            {
                Id = DishIdForDelete,
                CategoryId = CategoryIdWithDishes,
                Name = "Pizza Carbonara",
                Price = 12.99,
                PercentageDiscount = 5.0,
                Description = "Pasta with eggs, cheese, pancetta, and black pepper.",
                Calories = 450
            },
            new()
            {
                Id = Guid.Parse("55C1CDA0-36A9-4A4D-9326-0B5F26E295C0"),
                CategoryId = CategoryIdWithDishes,
                Name = "Margherita Pizza",
                Price = 9.99,
                PercentageDiscount = null,
                Description = "Pizza topped with tomato sauce, mozzarella cheese, and basil.",
                Calories = 800
            },
            new()
            {
                Id = DishIdForUpdate,
                CategoryId = Guid.Parse("55C1CDA0-36A9-4A4D-9326-0B5F26E295CD"),
                Name = "Caesar Salad",
                Price = 8.25,
                PercentageDiscount = 0,
                Description = "Fresh romaine lettuce, croutons, Parmesan cheese, and Caesar dressing.",
                Calories = 180
            }
        };

        return dishes;
    }

    private static IEnumerable<Order> GetMockOrders()
    {
        var orders = new List<Order>
        {
            new()
            {
                Id = Guid.Parse("038A1EC0-07AE-4680-A22A-B4C5D331871D"),
                UserId = FirstUserId,
                OrderDate = DateTime.Now,
                Status = OrderConstants.Status.Pending,
                OrderItems = new List<OrderItem>
                {
                    new() { Id = Guid.NewGuid(), DishId = DishIdForUpdate, Quantity = 2 },
                    new() { Id = Guid.NewGuid(), DishId = DishIdForUpdate, Quantity = 1 },
                }
            },
            new()
            {
                Id = OrderIdForUpdate,
                UserId = SecondUserId,
                OrderDate = DateTime.Now,
                Status = OrderConstants.Status.Delivered,
                OrderItems = new List<OrderItem>
                {
                    new() { Id = Guid.NewGuid(), DishId = DishIdForUpdate, Quantity = 3 },
                    new() { Id = Guid.NewGuid(), DishId = DishIdForUpdate, Quantity = 1 },
                }
            },
        };

        return orders;
    }
}