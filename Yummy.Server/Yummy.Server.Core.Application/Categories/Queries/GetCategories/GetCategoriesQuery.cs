using MediatR;

namespace Yummy.Server.Application.Categories.Queries.GetCategories;

public class GetCategoriesQuery : IRequest<GetCategoriesListDto>
{
}