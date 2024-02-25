using Yummy.Server.Application.Dishes.Commands.UpdateDish;

namespace Yummy.Server.Tests.Dishes.Commands;

public class UpdateDishCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task UpdateDishCommandHandler_Success()
    {
        // Arrange
        var newName = "American Burger";

        var handler = new UpdateDishCommandHandler(Context);

        // Act
        await handler.Handle(new UpdateDishCommand
        {
            Id = YummyDbContextFactory.DishIdForUpdate,
            CategoryId = YummyDbContextFactory.CategoryIdWithDishes,
            Name = newName,
        }, CancellationToken.None);

        // Assert
        var dishDb = await Context.Dishes
            .SingleOrDefaultAsync(dish => dish.Id == YummyDbContextFactory.DishIdForUpdate
                                              && dish.Name == newName);
        Assert.NotNull(dishDb);
    }

    [Fact]
    public async Task UpdateDishCommand_FailOnWrongId()
    {
        // Arrange
        var handler = new UpdateDishCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAnyAsync<NotFoundException>(async () =>
        {
            await handler.Handle(new UpdateDishCommand
            {
                Id = Guid.NewGuid()
            }, CancellationToken.None);
        });
    }
}