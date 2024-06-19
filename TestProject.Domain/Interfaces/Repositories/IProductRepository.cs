using TestProject.Domain.Entities;

namespace TestProject.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetProductAsync(Guid Id, CancellationToken cancellationToken);
        Task<Product?> CreateProductAsync(Product product, CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
