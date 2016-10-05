using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonumentBackend.Test.Controllers
{
    [TestClass]
    public class MonumentControllerTest
    {
        [TestMethod]
        public void GetGivesAnEnumerableOfMonuments()
        {
            // Arrange
            MonumentController controller = ProvideMonumentController();

            // Act

            // Assert
        }

        private MonumentController ProvideMonumentController()
        {
            IMonumentDbContext context = new MonumentContextMock();
            IRepository repository = new MonumentRepositoryMock();
            MonumentController controller = new MonumentController();

            return controller;
        }
    }
}
