using AutoMapper;
using Yummy.Server.Application.Categories.Commands.CreateCategory;
using Yummy.Server.Application.Common.Mappings;

namespace Yummy.Server.WebApi.Models.Category;

public class CreateCategoryDto : IMapWith<CreateCategoryCommand>
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCategoryDto, CreateCategoryCommand>();
    }
}