using AutoMapper;
using Yummy.Server.Application.Common.Mappings;
using Yummy.Server.Domain;

namespace Yummy.Server.Application.Categories.Queries.GetCategoryWithDishes;

public class GetCategoryWithDishesDto : IMapWith<Category>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public IEnumerable<Dish>? Dishes { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Category, GetCategoryWithDishesDto>();
    }
}