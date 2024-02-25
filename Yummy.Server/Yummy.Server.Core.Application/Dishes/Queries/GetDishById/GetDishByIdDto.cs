using AutoMapper;
using Yummy.Server.Application.Categories.Queries.GetCategoryWithDishes;
using Yummy.Server.Application.Common.Mappings;
using Yummy.Server.Domain;

namespace Yummy.Server.Application.Dishes.Queries.GetDishById;

public class GetDishByIdDto : IMapWith<Dish>
{
    public Guid Id { get; set; }

    public Guid CategoryId { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }

    public double? PercentageDiscount { get; set; }

    public string? Description { get; set; }

    public double? Calories { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Dish, GetDishByIdDto>();
    }
}