namespace Yummy.Server.Persistence;

public static class YummyDbInitializer
{
    public static void Initialize(YummyDbContext context)
    {
        context.Database.EnsureCreated();
    }
}