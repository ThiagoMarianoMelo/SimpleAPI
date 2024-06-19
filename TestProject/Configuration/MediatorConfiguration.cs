using MediatR;
using TestProject.Application.Handlers;
using TestProject.Domain.Command;
using TestProject.Domain.Entities;

namespace TestProject.Configuration
{
    public static class MediatorConfiguration
    {
        public static void ConfigureMediator(this IServiceCollection services)
        {
            services.AddScoped<IMediator, Mediator>();
            services.AddScoped<IRequestHandler<GetProductByIdCommand, ResponseWithData<Product>>, GetProductByIdHandler>();
            services.AddScoped<IRequestHandler<CreateProductCommand, Response>, CreateProductHandler>();
            services.AddScoped<IRequestHandler<RegisterUserCommand, Response>, RegisterUserHandler>();
            services.AddScoped<IRequestHandler<LoginUserCommand, ResponseWithData<string>>, LoginUserHandler>();
        }
    }
}
