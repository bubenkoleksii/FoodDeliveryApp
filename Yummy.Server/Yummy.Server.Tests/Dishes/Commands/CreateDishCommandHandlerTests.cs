using Yummy.Server.Application.Dishes.Commands.CreateDish;

namespace Yummy.Server.Tests.Dishes.Commands;

public class CreateDishCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CreateDishCommandHandler_Success()
    {
        // Arrange
        var name = "Pizza Ukrainian";

        var handler = new CreateDishCommandHandler(Context);

        // Act
        var id = await handler.Handle(new CreateDishCommand
        {
            CategoryId = YummyDbContextFactory.CategoryIdWithDishes,
            Name = name,
            Price = 13.99,
        }, CancellationToken.None);

        // Assert
        var entityDb = await Context.Dishes.SingleOrDefaultAsync(entity => entity.Id == id);
        Assert.NotNull(entityDb);
    }
}