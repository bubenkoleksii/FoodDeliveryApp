using MediatR;

namespace Yummy.Server.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<Guid>
{
    public string Name { get; set; }

    public string? Description { get; set; }
}