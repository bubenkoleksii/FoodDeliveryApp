using MediatR;
using Microsoft.EntityFrameworkCore;
using Yummy.Server.Application.Common.Exceptions;
using Yummy.Server.Application.Interfaces;
using Yummy.Server.Domain;

namespace Yummy.Server.Application.Orders.Commands.UpdateOrderStatus;

public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand>
{
    private readonly IYummyDbContext _dbContext;

    public UpdateOrderStatusCommandHandler(IYummyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
    {
        if (!OrderConstants.Status.IsValidStatus(request.Status))
        {
            throw new InvalidOperationException($"Incorrect status type \"{request.Status}\" for order with id \"{request.Id}\"");
        }

        var order = await _dbContext.Orders
            .Where(e => e.Id == request.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (order == null)
            throw new NotFoundException(nameof(Order), request.Id);

        order.Status = request.Status.ToUpper();

        _dbContext.Orders.Update(order);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}