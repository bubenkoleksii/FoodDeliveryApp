using Yummy.Server.Application.Dishes.Commands.DeleteDish;

namespace Yummy.Server.Tests.Dishes.Commands;

public class DeleteDishCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task DeleteDishCommandHandler_Success()
    {
        // Arrange
        var handler = new DeleteDishCommandHandler(Context);

        // Act
        await handler.Handle(new DeleteDishCommand
        {
            Id = YummyDbContextFactory.DishIdForDelete
        }, CancellationToken.None);


        // Assert
        var deletedDish = await Context.Dishes
            .SingleOrDefaultAsync(entity => entity.Id == YummyDbContextFactory.DishIdForDelete);

        Assert.Null(deletedDish);
    }

    [Fact]
    public async Task DeleteDishCommandHandler_FailOnWrongId()
    {
        // Arrange
        var handler = new DeleteDishCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new DeleteDishCommand
                {
                    Id = Guid.NewGuid(),
                },
                CancellationToken.None)
        );
    }
}