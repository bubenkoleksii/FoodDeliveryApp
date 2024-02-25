using Yummy.Server.Application.Orders;
using Yummy.Server.Application.Orders.Commands.UpdateOrderStatus;

namespace Yummy.Server.Tests.Orders.Commands;

public class UpdateOrderStatusCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task UpdateOrderCommandHandler_Success()
    {
        // Arrange
        var newStatus = OrderConstants.Status.Shipped;

        var handler = new UpdateOrderStatusCommandHandler(Context);

        // Act
        await handler.Handle(new UpdateOrderStatusCommand
        {
            Id = YummyDbContextFactory.OrderIdForUpdate,
            Status = newStatus,
        }, CancellationToken.None);

        // Assert
        var orderDb = await Context.Orders
            .SingleOrDefaultAsync(order => order.Id == YummyDbContextFactory.OrderIdForUpdate
                && order.Status == newStatus
            );

        Assert.NotNull(orderDb);
    }

    [Fact]
    public async Task UpdateOrderCommand_FailOnWrongId()
    {
        // Arrange
        var handler = new UpdateOrderStatusCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAnyAsync<NotFoundException>(async () =>
        {
            await handler.Handle(new UpdateOrderStatusCommand
            {
                Id = Guid.NewGuid(),
                Status = OrderConstants.Status.Delivered
            }, CancellationToken.None);
        });
    }
}