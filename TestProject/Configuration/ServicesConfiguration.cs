using Microsoft.AspNetCore.Identity;
using TestProject.Application;
using TestProject.Application.Services;
using TestProject.Domain.Entities;
using TestProject.Domain.Interfaces;
using TestProject.Domain.Interfaces.Services;

namespace TestProject.Configuration
{
    public static class ServicesConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthUser, AuthUser>();

            services.AddScoped<UserManager<User>>();

        }
    }
}
