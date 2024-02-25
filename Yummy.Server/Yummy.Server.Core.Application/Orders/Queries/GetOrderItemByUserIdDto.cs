namespace Yummy.Server.Application.Orders.Queries;

public class GetOrderItemByUserIdDto
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Guid DishId { get; set; }

    public int Quantity { get; set; }
}