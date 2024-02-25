using FluentValidation;

namespace Yummy.Server.Application.Dishes.Commands.DeleteDish;

public class DeleteDishCommandValidator : AbstractValidator<DeleteDishCommand>
{
    public DeleteDishCommandValidator()
    {
        RuleFor(dish => dish.Id)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}