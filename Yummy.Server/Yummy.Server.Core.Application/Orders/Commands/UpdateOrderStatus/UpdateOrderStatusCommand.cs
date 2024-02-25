using MediatR;

namespace Yummy.Server.Application.Orders.Commands.UpdateOrderStatus;

public class UpdateOrderStatusCommand : IRequest
{
    public Guid Id { get; set; }

    public string Status { get; set; }
}