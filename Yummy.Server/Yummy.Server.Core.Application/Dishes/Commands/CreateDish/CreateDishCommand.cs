using MediatR;

namespace Yummy.Server.Application.Dishes.Commands.CreateDish;

public class CreateDishCommand : IRequest<Guid>
{
    public Guid CategoryId { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }

    public double? PercentageDiscount { get; set; }

    public string? Description { get; set; }

    public double? Calories { get; set; }
}