using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonumentBackend.Controllers;
using MonumentBackend.Entities;
using MonumentBackend.Test.Mocks;
using System.Collections.Generic;
using System.Linq;

namespace MonumentBackend.Test.Controllers
{
    [TestClass]
    public class MonumentControllerTest
    {
        [TestMethod]
        public void All()
        {
            // Arrange
            MonumentRepositoryMock repository = new MonumentRepositoryMock();

            repository.Insert(new Monument(1, "The Taj Mahal"));
            repository.Insert(new Monument(2, "The Great Wall of China"));

            MonumentController controller = new MonumentController(repository);

            // Act
            IEnumerable<Monument> monuments = controller.All();

            // Assert
            Assert.AreEqual(2, monuments.Count());
            Assert.IsTrue(repository.FindAllIsCalled);
        }

        [TestMethod]
        public void Get()
        {
            // Arrange
            MonumentRepositoryMock repository = new MonumentRepositoryMock();

            repository.Insert(new Monument(1, "The Taj Mahal"));
            repository.Insert(new Monument(2, "The Great Wall of China"));

            MonumentController controller = new MonumentController(repository);

            // Act
            int id = 1;
            Monument monument = controller.Get(id);

            // Assert
            Assert.AreEqual(id, monument.ID);
            Assert.IsTrue(repository.FindIsCalled);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            MonumentRepositoryMock repository = new MonumentRepositoryMock();
            MonumentController controller = new MonumentController(repository);

            // Act
            string name = "The Egyptian Pyramids";
            controller.Post(1, name);

            // Assert
            Assert.AreEqual(1, repository.Count());
            Assert.IsTrue(repository.InsertIsCalled);
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            MonumentRepositoryMock repository = new MonumentRepositoryMock();
            MonumentController controller = new MonumentController(repository);
            Monument monument = new Monument(1, "My Backyard");

            // Act
            repository.Insert(new Monument(1, "Great Wall of China"));
            controller.Put(monument);

            // Assert
            Assert.AreEqual(1, repository.Count());
            Assert.IsTrue(repository.UpdateIsCalled);
            Assert.AreEqual(monument, repository.Find(1));
        }
    }
}
