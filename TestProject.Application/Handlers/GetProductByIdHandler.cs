using MediatR;
using TestProject.Domain.Command;
using TestProject.Domain.Entities;
using TestProject.Domain.Interfaces.Repositories;

namespace TestProject.Application.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdCommand, ResponseWithData<Product>>
    {
        private readonly IProductRepository ProductRepository;
        public GetProductByIdHandler(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public async Task<ResponseWithData<Product>> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.Id == Guid.Empty)
            {
                return new ResponseWithData<Product>() { Success = false };
            }

            var result = await ProductRepository.GetProductAsync(request.Id, cancellationToken);

            return new ResponseWithData<Product>() { Success = true, Data = result };

        }
    }
}
