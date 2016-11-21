using WebAPIServiceLayer.Domain.Entities;

namespace WebAPIServiceLayer.Domain.Repositories
{
    public interface IProductRepository : IFullRepository<Product, int>
    {
    }
}
