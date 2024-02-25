using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Yummy.Identity.Models;

namespace Yummy.Identity.Data;

public class YummyAuthDbContext : IdentityDbContext<AppUser>
{
    public YummyAuthDbContext(DbContextOptions<YummyAuthDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<AppUser>(entity => entity.ToTable(name: "Users"));
        builder.Entity<IdentityRole>(entity => entity.ToTable(name: "Roles"));
        builder.Entity<IdentityUserRole<string>>(entity => entity.ToTable(name: "UserRoles"));
        builder.Entity<IdentityUserClaim<string>>(entity => entity.ToTable(name: "UserClaim"));
        builder.Entity<IdentityUserLogin<string>>(entity => entity.ToTable(name: "UserLogins"));
        builder.Entity<IdentityUserToken<string>>(entity => entity.ToTable(name: "UserTokens"));
        builder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable(name: "RoleClaims"));

        builder.ApplyConfiguration(new AppUsersConfiguration());

        base.OnModelCreating(builder);
    }
}