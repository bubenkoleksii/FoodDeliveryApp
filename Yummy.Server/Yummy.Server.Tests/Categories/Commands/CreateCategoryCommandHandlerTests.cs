using Yummy.Server.Application.Categories.Commands.CreateCategory;

namespace Yummy.Server.Tests.Categories.Commands;

public class CreateCategoryCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CreateCategoryCommandHandler_Success()
    {
        // Arrange
        var categoryName = "Soups";
        var categoryDescription = "Wonderful soups of Ukrainian, Asian and European cuisines";

        var handler = new CreateCategoryCommandHandler(Context);

        // Act
        var categoryId = await handler.Handle(new CreateCategoryCommand
        {
            Name = categoryName,
            Description = categoryDescription
        }, CancellationToken.None);

        // Assert
        var entityDb = await Context.Categories.SingleOrDefaultAsync(entity => entity.Id == categoryId);
        Assert.NotNull(entityDb);
    }
}