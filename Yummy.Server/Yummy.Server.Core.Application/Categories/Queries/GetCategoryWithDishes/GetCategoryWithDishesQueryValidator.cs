using FluentValidation;

namespace Yummy.Server.Application.Categories.Queries.GetCategoryWithDishes;

public class GetCategoryWithDishesQueryValidator : AbstractValidator<GetCategoryWithDishesQuery>
{
    public GetCategoryWithDishesQueryValidator()
    {
        RuleFor(getCategoryWithDishesQuery => getCategoryWithDishesQuery.Id)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}