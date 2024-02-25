using Yummy.Server.Application.Categories.Queries.GetCategoryWithDishes;

namespace Yummy.Server.Tests.Categories.Queries;

[Collection("QueryCollection")]
public class GetCategoryWithDishesQueryHandlerTests
{
    private readonly YummyDbContext Context;

    private readonly IMapper Mapper;

    public GetCategoryWithDishesQueryHandlerTests(QueryTestFixture queryTestFixture)
    {
        Context = queryTestFixture.Context;
        Mapper = queryTestFixture.Mapper;
    }

    [Fact]
    public async Task GetCategoryWithDishesQueryHandler_Success()
    {
        // Arrange
        var handler = new GetCategoryWithDishesQueryHandler(Context, Mapper);

        // Act
        var category = await handler.Handle(new GetCategoryWithDishesQuery
        {
            Id = YummyDbContextFactory.CategoryIdWithDishes
        }, CancellationToken.None);

        // Assert
        category.ShouldBeOfType<GetCategoryWithDishesDto>();
        category.Dishes.Count().ShouldBe(2);
    }
}