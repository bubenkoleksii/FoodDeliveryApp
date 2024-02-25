using AutoMapper;
using Yummy.Server.Application.Common.Mappings;
using Yummy.Server.Application.Orders.Commands.UpdateOrderStatus;

namespace Yummy.Server.WebApi.Models.Order;

public class UpdateOrderStatusDto : IMapWith<UpdateOrderStatusCommand>
{
    public Guid Id { get; set; }

    public string Status { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateOrderStatusDto, UpdateOrderStatusCommand>();
    }
}