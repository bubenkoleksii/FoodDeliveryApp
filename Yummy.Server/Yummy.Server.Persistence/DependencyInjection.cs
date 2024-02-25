using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yummy.Server.Application.Interfaces;

namespace Yummy.Server.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];

        services.AddDbContext<YummyDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddScoped<IYummyDbContext>(provider => provider.GetService<YummyDbContext>()!);

        return services;
    }
}