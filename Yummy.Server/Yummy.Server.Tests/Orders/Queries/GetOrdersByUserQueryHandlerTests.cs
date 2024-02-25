using Yummy.Server.Application.Orders.Queries;

namespace Yummy.Server.Tests.Orders.Queries;

[Collection("QueryCollection")]
public class GetOrdersByUserQueryHandlerTests
{
    private readonly YummyDbContext Context;

    private readonly IMapper Mapper;

    public GetOrdersByUserQueryHandlerTests(QueryTestFixture queryTestFixture)
    {
        Context = queryTestFixture.Context;
        Mapper = queryTestFixture.Mapper;
    }

    [Fact]
    public async Task GetOrdersByUserQueryHandler_Success()
    {
        // Arrange
        var handler = new GetOrdersByUserIdQueryHandler(Context, Mapper);

        // Act
        var orders = await handler.Handle(new GetOrdersByUserIdQuery
        {
            UserId = YummyDbContextFactory.FirstUserId
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(orders);

        orders.ShouldBeOfType<GetOrdersByUserIdListDto>();
        orders.Orders.Count.ShouldBe(1);
    }
}