using MediatR;

namespace Yummy.Server.Application.Categories.Queries.GetCategoryWithDishes;

public class GetCategoryWithDishesQuery : IRequest<GetCategoryWithDishesDto>
{
    public Guid Id { get; set; }
}