using BackendService.Domain.Entities;
using BackendService.Domain.Repositories;
using BackendService.Infrastructure.DataAccessLayer;
using BackendService.Infrastructure.Factories;
using System.Collections.Generic;

namespace BackendService.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product, SupermarketDbContext>, IProductRepository
    {       
        public ProductRepository(IManufacturesContext<SupermarketDbContext> factory) : base(factory)
        {
        }

        public Product Find(int key)
        {
            Product product = FindOneBy(p => p.ID == key);

            if (product == null)
            {
                throw new KeyNotFoundException();
            }

            return product;
        }
    }
}
