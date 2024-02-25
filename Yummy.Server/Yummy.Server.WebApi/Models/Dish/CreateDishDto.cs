using AutoMapper;
using Yummy.Server.Application.Common.Mappings;
using Yummy.Server.Application.Dishes.Commands.CreateDish;

namespace Yummy.Server.WebApi.Models.Dish;

public class CreateDishDto : IMapWith<CreateDishCommand>
{
    public Guid CategoryId { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }

    public double? PercentageDiscount { get; set; }

    public string? Description { get; set; }

    public double? Calories { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateDishDto, CreateDishCommand>();
    }
}