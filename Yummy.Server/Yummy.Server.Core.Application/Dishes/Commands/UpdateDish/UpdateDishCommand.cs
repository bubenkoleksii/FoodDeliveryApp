using MediatR;

namespace Yummy.Server.Application.Dishes.Commands.UpdateDish;

public class UpdateDishCommand : IRequest
{
    public Guid Id { get; set; }

    public Guid CategoryId { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }

    public double? PercentageDiscount { get; set; }

    public string? Description { get; set; }

    public double? Calories { get; set; }
}