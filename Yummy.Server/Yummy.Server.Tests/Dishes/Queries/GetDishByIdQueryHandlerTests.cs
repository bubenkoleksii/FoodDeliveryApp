using Yummy.Server.Application.Dishes.Queries.GetDishById;

namespace Yummy.Server.Tests.Dishes.Queries;

[Collection("QueryCollection")]
public class GetDishByIdQueryHandlerTests
{
    private readonly YummyDbContext Context;

    private readonly IMapper Mapper;

    public GetDishByIdQueryHandlerTests(QueryTestFixture queryTestFixture)
    {
        Context = queryTestFixture.Context;
        Mapper = queryTestFixture.Mapper;
    }

    [Fact]
    public async Task GetDishByIdQueryHandler_Success()
    {
        // Arrange
        var handler = new GetDishByIdQueryHandler(Context, Mapper);

        // Act
        var dish = await handler.Handle(new GetDishByIdQuery
        {
            Id = YummyDbContextFactory.DishIdForUpdate
        }, CancellationToken.None);

        // Assert
        dish.ShouldBeOfType<GetDishByIdDto>();

        Assert.NotNull(dish);
        Assert.Equal(YummyDbContextFactory.DishIdForUpdate, dish.Id);
    }
}