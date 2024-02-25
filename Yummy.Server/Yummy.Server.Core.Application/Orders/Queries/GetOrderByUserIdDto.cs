using AutoMapper;
using Yummy.Server.Application.Common.Mappings;
using Yummy.Server.Domain;

namespace Yummy.Server.Application.Orders.Queries;

public class GetOrderByUserIdDto : IMapWith<Order>
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public DateTime OrderDate { get; set; }

    public string Status { get; set; }

    public IEnumerable<GetOrderItemByUserIdDto> OrderItems { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, GetOrderByUserIdDto>();
    }
}