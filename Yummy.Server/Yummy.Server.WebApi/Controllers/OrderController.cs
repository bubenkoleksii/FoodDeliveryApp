using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yummy.Server.Application.Orders.Commands.CreateOrder;
using Yummy.Server.Application.Orders.Commands.UpdateOrderStatus;
using Yummy.Server.Application.Orders.Queries;
using Yummy.Server.WebApi.Models.Order;

namespace Yummy.Server.WebApi.Controllers;

[Route("api/[controller]")]
public class OrderController : BaseController
{
    private readonly IMapper _mapper;

    public OrderController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<GetOrdersByUserIdListDto>> GetOrders(int? skip, int? limit)
    {
        var query = new GetOrdersByUserIdQuery
        {
            UserId = UserId,
            Limit = limit,
            Skip = skip
        };

        var orders = await Mediator.Send(query);
        return Ok(orders);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateOrderDto createOrderDto)
    {
        var command = _mapper.Map<CreateOrderCommand>(createOrderDto); 
        command.UserId = UserId;

        var id = await Mediator.Send(command);
        return Ok(id);
    }

    [HttpPatch]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> UpdateStatus([FromBody] UpdateOrderStatusDto updateOrderStatusDto)
    {
        var command = _mapper.Map<UpdateOrderStatusCommand>(updateOrderStatusDto);

        await Mediator.Send(command);
        return NoContent();
    }
}