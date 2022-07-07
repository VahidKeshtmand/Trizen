using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using T.Domain.Account;
using T.Persistence.Contexts.SqlServerDb;

namespace T.Infrastructure.IdentityConfigs
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection service,
            IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:SqlServer"];
            service.AddDbContext<IdentityDatabaseContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            service.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<IdentityDatabaseContext>()
                .AddDefaultTokenProviders()
                .AddRoles<Role>()
                .AddErrorDescriber<CustomIdentityError>();

            
            service.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;

            });
            
            return service;
        }
    }
}
