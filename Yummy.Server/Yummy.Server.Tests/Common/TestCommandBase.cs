namespace Yummy.Server.Tests.Common;

public abstract class TestCommandBase : IDisposable
{
    protected readonly YummyDbContext Context;

    protected TestCommandBase()
    {
        Context = YummyDbContextFactory.Create();

        Context.ChangeTracker.Clear();
    }

    public void Dispose()
    {
        YummyDbContextFactory.Destroy(Context);
    }
}