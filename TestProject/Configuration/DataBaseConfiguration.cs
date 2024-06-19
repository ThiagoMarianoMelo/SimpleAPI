using Microsoft.EntityFrameworkCore;
using TestProject.Data.Context;

namespace TestProject.Configuration
{
    public static class DataBaseConfiguration
    {
        public static void ConfigureDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TestContext>(options => {

                options.UseNpgsql(connectionString: configuration.GetConnectionString("DataBase"));

            });
        }
    }
}
