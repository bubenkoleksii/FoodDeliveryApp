using Yummy.Server.Application.Categories.Commands.UpdateCategory;

namespace Yummy.Server.Tests.Categories.Commands;

public class UpdateCategoryCommandHandlerTests : TestCommandBase
{

    [Fact]
    public async Task UpdateCategoryCommandHandler_Success()
    {
        // Arrange
        var newName = "Burgers";

        var handler = new UpdateCategoryCommandHandler(Context);

        // Act
        await handler.Handle(new UpdateCategoryCommand
        {
            Id = YummyDbContextFactory.CategoryIdForUpdate,
            Name = newName,
        }, CancellationToken.None);

        // Assert
        var categoryDb = await Context.Categories
            .SingleOrDefaultAsync(category => category.Id == YummyDbContextFactory.CategoryIdForUpdate
                                              && category.Name == newName);
        Assert.NotNull(categoryDb);
    }

    [Fact]
    public async Task UpdateCategoryCommand_FailOnWrongId()
    {
        // Arrange
        var handler = new UpdateCategoryCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAnyAsync<NotFoundException>(async () =>
        {
            await handler.Handle(new UpdateCategoryCommand
            {
                Id = Guid.NewGuid()
            }, CancellationToken.None);
        });
    }
}