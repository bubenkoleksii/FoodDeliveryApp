using MediatR;
using Microsoft.EntityFrameworkCore;
using Yummy.Server.Application.Common.Exceptions;
using Yummy.Server.Application.Interfaces;
using Yummy.Server.Domain;

namespace Yummy.Server.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IYummyDbContext _dbContext;

    public CreateOrderCommandHandler(IYummyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            Id = new Guid(),
            UserId = request.UserId,
            OrderDate = DateTime.UtcNow,
            Status = OrderConstants.Status.Pending
        };

        foreach (var item in request.OrderItems)
        {
            var dish = await _dbContext.Dishes
                .Where(c => c.Id == item.DishId)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if (dish == null)
                throw new NotFoundException(nameof(Dish), item.DishId);

            item.Id = new Guid();
        }

        order.OrderItems = request.OrderItems;

        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}