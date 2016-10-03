using DatabaseCodeFirst.Application.Repositories;
using DatabaseCodeFirst.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseCodeFirst.Test.Application
{
    [TestClass]
    public class TestFestivalRepository
    {
        [TestMethod]
        public void FestivalRepositoryInitiallyHasNoFestivals()
        {
            // Arrange
            IRepository<Festival, int> repository = new FestivalRepository();

            // Act
            int count = repository.Count();

            // Assert
            Assert.AreEqual(0, count);
        }
    }
}
