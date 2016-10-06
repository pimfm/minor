using WebAPIServiceLayer.Domain.Entities;

using System.Collections.Generic;
using WebAPIServiceLayer.Domain.Repositories;

namespace WebAPIServiceLayer.Application.Controllers
{
    public class ProductController
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> All()
        {
            return _repository.FindAll();
        }

        public Product Find(int key)
        {
            return _repository.Find(key);
        }

        public void Add(string name)
        {
            Product newProduct = new Product(name, 0.00M);

            _repository.Insert(newProduct);
        }
    }
}