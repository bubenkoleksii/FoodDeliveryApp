using FluentValidation;

namespace Yummy.Server.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(createDish => createDish.CategoryId)
            .NotNull()
            .NotEqual(Guid.Empty);

        RuleFor(createDish => createDish.Name)
            .NotNull()
            .NotEmpty()
            .NotEqual(string.Empty)
            .MaximumLength(250);

        RuleFor(createDish => createDish.Price)
            .NotNull()
            .GreaterThan(0);
    }
}