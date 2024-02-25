using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Yummy.Server.Application.Interfaces;
using Yummy.Server.Domain;

namespace Yummy.Server.Application.Orders.Queries;

public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, GetOrdersByUserIdListDto>
{
    private readonly IYummyDbContext _dbContext;

    private readonly IMapper _mapper;

    public GetOrdersByUserIdQueryHandler(IYummyDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetOrdersByUserIdListDto> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Order> query = _dbContext.Orders
            .Where(o => o.UserId == request.UserId)
            .OrderByDescending(o => o.OrderDate);

        if (request.Skip.HasValue)
            query = query.Skip((int)request.Skip);

        if (request.Limit.HasValue)
            query = query.Take(request.Limit.Value);

        var orders = await query.ToListAsync(cancellationToken);

        var ordersDto = _mapper.Map<List<GetOrderByUserIdDto>>(orders);
        foreach (var order in ordersDto)
        {
            var orderItems = await _dbContext.OrderItems
                .Where(item => item.OrderId == order.Id)
                .Select(item => new GetOrderItemByUserIdDto
                {
                    Id = item.Id,
                    OrderId = item.OrderId,
                    DishId = item.DishId,
                    Quantity = item.Quantity
                })
                .ToListAsync(cancellationToken);

            order.OrderItems = orderItems;
        }

        return new GetOrdersByUserIdListDto
        {
            Orders = ordersDto,
            Skip = request.Skip,
            Limit = request.Limit
        };
    }
}