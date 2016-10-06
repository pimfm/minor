using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebAPIServiceLayer.Domain.Entities;
using WebAPIServiceLayer.Domain.Repositories;
using WebAPIServiceLayer.Test.Infrastructure.DataAccessLayer;

namespace WebAPIServiceLayer.Test.Infrastructure.Repositories.Mocks
{
    internal class ProductRepositoryMock : IProductRepository<InMemorySupermarketContext>
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Product item)
        {
            throw new NotImplementedException();
        }

        public Product Find(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> FindAll()
        {
            List<Product> products = new List<Product>()
            {
                new Product("CLUB-MATE", 2.99M),
                new Product("Green", 1.06M, "Lipton")
            };

            return products;
        }

        public IEnumerable<Product> FindBy(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product item)
        {
            throw new NotImplementedException();
        }

        public void Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}