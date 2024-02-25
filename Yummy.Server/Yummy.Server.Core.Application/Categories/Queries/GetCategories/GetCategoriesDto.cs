using AutoMapper;
using Yummy.Server.Application.Common.Mappings;
using Yummy.Server.Domain;

namespace Yummy.Server.Application.Categories.Queries.GetCategories;

public class GetCategoriesDto : IMapWith<Category>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Category, GetCategoriesDto>();
    }
}