namespace Yummy.Server.Application.Orders.Queries;

public class GetOrdersByUserIdListDto
{
    public IList<GetOrderByUserIdDto> Orders { get; set; }

    public int? Skip { get; set; }

    public int? Limit { get; set; }
}