using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using T.Persistence.Contexts.SqlServerDb;

namespace T.Infrastructure.SetupServices
{
    public class SqlServerSetup
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
