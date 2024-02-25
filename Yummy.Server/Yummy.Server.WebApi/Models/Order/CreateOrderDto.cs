using AutoMapper;
using Yummy.Server.Application.Common.Mappings;
using Yummy.Server.Application.Orders.Commands.CreateOrder;
using Yummy.Server.Domain;
using Yummy.Server.WebApi.Models.Category;

namespace Yummy.Server.WebApi.Models.Order;

public class CreateOrderDto : IMapWith<CreateOrderCommand>
{
    public IEnumerable<CreateOrderItemDto> OrderItems { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrderDto, CreateOrderCommand>();
    }
}