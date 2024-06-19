using TestProject.Data.Repositories;
using TestProject.Domain.Interfaces.Repositories;

namespace TestProject.Configuration
{
    public static class RepositoryConfiguration
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
