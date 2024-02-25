using FluentValidation;
using Yummy.Server.Application.Categories.Queries.GetCategoryWithDishes;

namespace Yummy.Server.Application.Dishes.Queries.GetDishById;

public class GetDishByIdQueryValidator : AbstractValidator<GetCategoryWithDishesQuery>
{
    public GetDishByIdQueryValidator()
    {
        RuleFor(dish => dish.Id)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}