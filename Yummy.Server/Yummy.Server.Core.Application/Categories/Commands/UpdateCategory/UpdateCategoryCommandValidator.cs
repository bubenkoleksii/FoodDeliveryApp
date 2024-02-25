using FluentValidation;

namespace Yummy.Server.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(updateCategoryCommand => updateCategoryCommand.Name)
            .NotEmpty()
            .MaximumLength(250);

        RuleFor(updateCategoryCommand => updateCategoryCommand.Id)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}