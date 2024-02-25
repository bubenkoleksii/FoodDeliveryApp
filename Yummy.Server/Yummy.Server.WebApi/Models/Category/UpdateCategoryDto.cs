using AutoMapper;
using Yummy.Server.Application.Categories.Commands.UpdateCategory;
using Yummy.Server.Application.Common.Mappings;

namespace Yummy.Server.WebApi.Models.Category;

public class UpdateCategoryDto : IMapWith<UpdateCategoryCommand>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateCategoryDto, UpdateCategoryCommand>();
    }
}