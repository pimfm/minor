using System;
using Microsoft.EntityFrameworkCore;
using WebAPIServiceLayer.Domain.Entities;
using WebAPIServiceLayer.Domain.Repositories;
using WebAPIServiceLayer.Infrastructure.DataAccessLayer;
using WebAPIServiceLayer.Infrastructure.Factories;

namespace WebAPIServiceLayer.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product, SupermarketDbContext>, IProductRepository<SupermarketDbContext>
    {
        private IManufacturesContext<SupermarketDbContext> _factory;

        public ProductRepository(IManufacturesContext<SupermarketDbContext> factory)
        {
            _factory = factory;
        }

        public Product Find(int key)
        {
            throw new NotImplementedException();
        }

        public override DbSet<Product> ProvideDatabaseSet()
        {
            using (SupermarketDbContext context = _factory.ManufactureContext())
            {
                return context.Products;
            }
        }
    }
}
