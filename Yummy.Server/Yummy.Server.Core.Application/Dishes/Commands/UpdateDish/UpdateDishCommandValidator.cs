using FluentValidation;

namespace Yummy.Server.Application.Dishes.Commands.UpdateDish;

public class UpdateDishCommandValidator : AbstractValidator<UpdateDishCommand>
{
    public UpdateDishCommandValidator()
    {
        RuleFor(dish => dish.CategoryId)
            .NotNull()
            .NotEqual(Guid.Empty);

        RuleFor(dish => dish.Name)
            .NotNull()
            .NotEmpty()
            .NotEqual(string.Empty)
            .MaximumLength(250);

        RuleFor(dish => dish.Price)
            .NotNull()
            .GreaterThan(0);

        RuleFor(dish => dish.Id)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}