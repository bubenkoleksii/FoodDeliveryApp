using AutoMapper;
using Yummy.Server.Application.Common.Mappings;
using Yummy.Server.Domain;

namespace Yummy.Server.WebApi.Models.Order;

public class CreateOrderItemDto : IMapWith<OrderItem>
{
    public Guid DishId { get; set; }

    public int Quantity { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrderItemDto, OrderItem>();
    }
}