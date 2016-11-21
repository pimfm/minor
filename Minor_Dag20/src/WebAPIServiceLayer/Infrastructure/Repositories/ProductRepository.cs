using WebAPIServiceLayer.Domain.Entities;
using WebAPIServiceLayer.Domain.Repositories;
using WebAPIServiceLayer.Infrastructure.DataAccessLayer;
using WebAPIServiceLayer.Infrastructure.Factories;
using System.Collections.Generic;

namespace WebAPIServiceLayer.Infrastructure.Repositories
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
