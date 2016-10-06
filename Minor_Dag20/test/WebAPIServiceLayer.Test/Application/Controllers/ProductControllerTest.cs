using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WebAPIServiceLayer.Application.Controllers;
using WebAPIServiceLayer.Domain.Entities;
using WebAPIServiceLayer.Domain.Repositories;
using WebAPIServiceLayer.Test.Infrastructure.Repositories.Mocks;

namespace WebAPIServiceLayer.Test.Application.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void All()
        {
            // Arrange
            IProductRepository repository = new ProductRepositoryMock();
            ProductController controller = new ProductController(repository);

            // Act
            IEnumerable<Product> products = controller.All();

            // Assert
            
        }
    }
}
