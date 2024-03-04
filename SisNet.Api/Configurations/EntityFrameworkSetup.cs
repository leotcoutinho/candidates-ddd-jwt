using Microsoft.EntityFrameworkCore;
using SisNet.Database.Context;

namespace SisNet.Api.Configurations
{
    public static class EntityFrameworkSetup
    {
        public static void AddEntityFrameworkSetup(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<SqlContext>
                    (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
