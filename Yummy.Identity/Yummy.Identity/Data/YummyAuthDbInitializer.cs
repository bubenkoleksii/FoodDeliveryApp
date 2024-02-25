namespace Yummy.Identity.Data;

public static class YummyAuthDbInitializer
{
    public static void Initialize(YummyAuthDbContext dbContext)
    {
        dbContext.Database.EnsureCreated();
    }
}