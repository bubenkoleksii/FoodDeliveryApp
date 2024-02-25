using MediatR;

namespace Yummy.Server.Application.Orders.Queries;

public class GetOrdersByUserIdQuery : IRequest<GetOrdersByUserIdListDto>
{
    public Guid UserId { get; set; }

    public int? Skip { get; set; }

    public int? Limit { get; set; }
}