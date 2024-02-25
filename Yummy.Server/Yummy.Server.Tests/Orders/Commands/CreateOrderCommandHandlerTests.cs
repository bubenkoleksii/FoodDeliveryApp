using Yummy.Server.Application.Orders.Commands.CreateOrder;

namespace Yummy.Server.Tests.Orders.Commands;

public class CreateOrderCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CreateOrderCommandHandler_Success()
    {
        // Arrange
        var handler = new CreateOrderCommandHandler(Context);

        // Act
        var id = await handler.Handle(new CreateOrderCommand
        {
            UserId = YummyDbContextFactory.FirstUserId,
            OrderItems = new List<OrderItem>
            {
                new()
                {
                    DishId = YummyDbContextFactory.DishIdForUpdate,
                    Quantity = 5,
                }
            }
        }, CancellationToken.None);

        // Assert
        var entityDb = await Context.Orders.SingleOrDefaultAsync(entity => entity.Id == id);
        Assert.NotNull(entityDb);
    }
}