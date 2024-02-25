using MediatR;

namespace Yummy.Server.Application.Dishes.Queries.GetDishById;

public class GetDishByIdQuery : IRequest<GetDishByIdDto>
{
    public Guid Id { get; set; }
}