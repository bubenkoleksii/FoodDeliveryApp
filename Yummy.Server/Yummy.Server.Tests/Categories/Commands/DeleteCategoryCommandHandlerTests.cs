using Yummy.Server.Application.Categories.Commands.DeleteCategory;

namespace Yummy.Server.Tests.Categories.Commands;

public class DeleteCategoryCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task DeleteCategoryCommandHandler_Success()
    {
        // Arrange
        var handler = new DeleteCategoryCommandHandler(Context);

        // Act
        await handler.Handle(new DeleteCategoryCommand
        {
            Id = YummyDbContextFactory.CategoryIdForDelete
        }, CancellationToken.None);


        // Assert
        var deletedCategory = await Context.Categories
            .SingleOrDefaultAsync(entity => entity.Id == YummyDbContextFactory.CategoryIdForDelete);

        Assert.Null(deletedCategory);
    }

    [Fact]
    public async Task DeleteCategoryCommandHandler_FailOnWrongId()
    {
        // Arrange
        var handler = new DeleteCategoryCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new DeleteCategoryCommand
                {
                    Id = Guid.NewGuid(),
                },
                CancellationToken.None)
            );
    }
}