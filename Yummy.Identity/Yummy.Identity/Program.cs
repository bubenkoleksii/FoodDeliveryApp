using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Yummy.Identity;
using Yummy.Identity.Data;
using Yummy.Identity.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<YummyAuthDbContext>(options =>
{
    var dbConnectionString = builder.Configuration.GetValue<string>("DbConnection");

    options.UseSqlite(dbConnectionString);
});

builder.Services.AddIdentity<AppUser, IdentityRole>(configuration =>
{
    configuration.Password.RequiredLength = 6;
    configuration.Password.RequireDigit = false;
    configuration.Password.RequireNonAlphanumeric = false;
    configuration.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<YummyAuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<AppUser>()
    .AddInMemoryApiResources(Configuration.ApiResources)
    .AddInMemoryIdentityResources(Configuration.IdentityResources)
    .AddInMemoryApiScopes(Configuration.ApiScopes)
    .AddInMemoryClients(Configuration.Clients)
    .AddDeveloperSigningCredential();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "Yummy.Identity.Cookie";
    options.LoginPath = "/Auth/Login";
    options.LogoutPath = "/Auth/Logout";
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    try
    {
        var dbContext = serviceProvider.GetRequiredService<YummyAuthDbContext>();
        YummyAuthDbInitializer.Initialize(dbContext);
    }
    catch (Exception e)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(e, "An error occurred while app initialization");
    }
}


// Managing roles
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    try
    {
        var roleExists = await roleManager.RoleExistsAsync("Administrator");

        if (!roleExists)
        {
            var role = new IdentityRole("Administrator");
            await roleManager.CreateAsync(role);
        }
    }
    catch (Exception e)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(e, "An error occurred while roles initialization");
    }
}

// Managing administrator
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
    try
    {
        var user = await userManager.FindByEmailAsync(Configuration.RootUserEmail);
        if (user != null)
        {
            await userManager.AddToRoleAsync(user, "Administrator");
        }
    }
    catch (Exception e)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(e, "An error occurred while roles initialization");
    }
}

app.UseIdentityServer();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.MapGet("/", () => "Yummy Identity!");

app.Run();
