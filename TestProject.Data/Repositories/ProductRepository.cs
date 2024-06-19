using Microsoft.EntityFrameworkCore;
using TestProject.Data.Context;
using TestProject.Domain.Entities;
using TestProject.Domain.Interfaces.Repositories;

namespace TestProject.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly TestContext Context;

        public ProductRepository(TestContext context)
        {
            Context = context;
        }

        public async Task<Product?> GetProductAsync(Guid Id, CancellationToken cancellationToken)
        {
            return await Context.Products.FirstOrDefaultAsync(p => p.Id == Id, cancellationToken);
        }

        public async Task<Product?> CreateProductAsync(Product product, CancellationToken cancellationToken)
        {
            var result = await Context.Products.AddAsync(product, cancellationToken);

            return result.Entity;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
