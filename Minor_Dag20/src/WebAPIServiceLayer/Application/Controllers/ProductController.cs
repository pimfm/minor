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
    }
}