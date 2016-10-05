using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor_Dag18.Controllers;
using Minor_Dag18.Entities;
using Minor_Dag18.Mocks;
using Minor_Dag18.Services;
using Minor_Dag18.Services.Agents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Minor_Dag18.Test.Controllers
{
    [TestClass]
    public class MonumentControllerTest
    {
        [TestMethod]
        public void MonumentControllerIsInstanceOfController()
        {
            // Arrange
            IMonumentAgent monumentAgent = new MonumentAgentMock();
            MonumentController controller = new MonumentController(monumentAgent);

            // Assert
            Assert.IsInstanceOfType(controller, typeof(Controller));
        }

        [TestMethod]
        public void MonumentControllerIndexGivesAViewResult()
        {
            // Arrange
            IMonumentAgent monumentAgent = new MonumentAgentMock();
            MonumentController controller = new MonumentController(monumentAgent);

            // Act
            IActionResult response = controller.Index();

            // Assert
            Assert.IsInstanceOfType(response, typeof(ViewResult));
        }

        [TestMethod]
        public void MonumentControllerIndexGivesTheViewAListOfMonumentsAsModel()
        {
            // Arrange
            IMonumentAgent monumentAgent = new MonumentAgentMock();
            MonumentController controller = new MonumentController(monumentAgent);

            // Act
            ViewResult response = controller.Index();
            IEnumerable<Monument> model = (IEnumerable<Monument>) response.Model;

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(model.ToList(), typeof(Monument));
        }

        [TestMethod]
        public void MonumentControllerProvidesTheModelUsingAnInjectedAgent()
        {
            // Arrange
            IMonumentAgent monumentAgent = new MonumentAgentMock();
            MonumentController controller = new MonumentController(monumentAgent);

            // Act
            ViewResult response = controller.Index();
            IEnumerable<Monument> model = (IEnumerable<Monument>)response.Model;

            // Assert
            Assert.AreEqual(3, model.Count());
            CollectionAssert.AllItemsAreInstancesOfType(model.ToList(), typeof(Monument));
        }
    }
}
