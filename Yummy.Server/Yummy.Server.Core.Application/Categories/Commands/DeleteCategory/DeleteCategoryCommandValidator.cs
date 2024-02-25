using FluentValidation;

namespace Yummy.Server.Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(deleteCategoryCommand => deleteCategoryCommand.Id)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}