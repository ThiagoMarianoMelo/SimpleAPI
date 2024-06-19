using AutoMapper;
using MediatR;
using TestProject.Domain.Command;
using TestProject.Domain.Entities;
using TestProject.Domain.Interfaces;
using TestProject.Domain.Interfaces.Repositories;

namespace TestProject.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Response>
    {
        private readonly IProductRepository Repository;
        private readonly IMapper Mapper;

        public CreateProductHandler(IProductRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public async Task<Response> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response() { Success = false };

            var newProduct = Mapper.Map<Product>(request);

            await Repository.CreateProductAsync(newProduct,cancellationToken);

            var result = await Repository.SaveChangesAsync(cancellationToken);

            return new Response() { Success = result >= 1 };

        }
    }
}
