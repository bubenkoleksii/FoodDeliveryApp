using MediatR;
using Yummy.Server.Domain;

namespace Yummy.Server.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }

    public IEnumerable<OrderItem> OrderItems { get; set; }
}