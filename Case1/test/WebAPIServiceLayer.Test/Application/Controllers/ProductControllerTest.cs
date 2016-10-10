using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using BackendService.Application.Controllers;
using BackendService.Domain.Entities;
using BackendService.Domain.Repositories;
using BackendService.Test.Infrastructure.Repositories.Mocks;

namespace BackendService.Test.Application.Controllers
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
