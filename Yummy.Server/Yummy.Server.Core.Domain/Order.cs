namespace Yummy.Server.Domain;

public class Order
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public DateTime OrderDate { get; set; }

    public string Status { get; set; }

    public IEnumerable<OrderItem> OrderItems { get; set; }
}