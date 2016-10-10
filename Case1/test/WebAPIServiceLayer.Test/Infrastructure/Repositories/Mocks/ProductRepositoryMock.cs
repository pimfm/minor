using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BackendService.Domain.Entities;
using BackendService.Domain.Repositories;

namespace BackendService.Test.Infrastructure.Repositories.Mocks
{
    internal class ProductRepositoryMock : IProductRepository
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
            Product foundProduct = new Product();
            foundProduct.ID = key;

            return foundProduct;
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

        public Product FindOneBy(Expression<Func<Product, bool>> filter)
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