using BackendService.Domain.Entities;

namespace BackendService.Domain.Repositories
{
    public interface IProductRepository : IFullRepository<Product, int>
    {
    }
}
