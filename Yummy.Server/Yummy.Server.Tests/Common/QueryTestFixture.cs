using Yummy.Server.Application.Common.Mappings;
using Yummy.Server.Application.Interfaces;

namespace Yummy.Server.Tests.Common;

public class QueryTestFixture : IDisposable
{
    public YummyDbContext Context;

    public IMapper Mapper;

    public QueryTestFixture()
    {
        Context = YummyDbContextFactory.Create();
        Context.ChangeTracker.Clear();

        var configurationBuilder = new MapperConfiguration(configure =>
        {
            configure.AddProfile(new AssemblyMappingProfile(typeof(IYummyDbContext).Assembly));
        });

        Mapper = configurationBuilder.CreateMapper();
    }

    public void Dispose()
    {
        YummyDbContextFactory.Destroy(Context);
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture>
    {
    }
}