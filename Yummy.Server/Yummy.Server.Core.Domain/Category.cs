namespace Yummy.Server.Domain;

public class Category
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public IEnumerable<Dish>? Dishes { get; set; }
}