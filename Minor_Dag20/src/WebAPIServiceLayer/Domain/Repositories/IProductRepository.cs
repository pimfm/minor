using WebAPIServiceLayer.Domain.Entities;

namespace WebAPIServiceLayer.Domain.Repositories
{
    public interface IProductRepository<ProductDbContext> : IFullRepository<Product, int>
    {
    }
}
