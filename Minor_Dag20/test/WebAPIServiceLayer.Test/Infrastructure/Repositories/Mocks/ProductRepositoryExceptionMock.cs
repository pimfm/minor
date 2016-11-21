using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebAPIServiceLayer.Domain.Entities;
using WebAPIServiceLayer.Domain.Repositories;

namespace WebAPIServiceLayer.Test.Infrastructure.Repositories.Mocks
{
    internal class ProductRepositoryExceptionMock : IProductRepository
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
            throw new KeyNotFoundException();
        }

        public IEnumerable<Product> FindAll()
        {
            throw new NotImplementedException();
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