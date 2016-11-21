using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
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
            Assert.AreEqual(2, products.Count());
        }

        [TestMethod]
        public void Get()
        {
            // Arrange
            IProductRepository repository = new ProductRepositoryMock();
            ProductController controller = new ProductController(repository);

            // Act
            Product product = controller.Find(1);

            // Assert
            Assert.AreEqual(1, product.ID);
        }

        [TestMethod]
        public void GetNotFound()
        {
            // Arrange
            IProductRepository repository = new ProductRepositoryExceptionMock();
            ProductController controller = new ProductController(repository);

            // Assert
            Assert.ThrowsException<KeyNotFoundException>(() => controller.Find(1));
        }
    }
}
