using EasyNetQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace TestMicroService.Domain.Test
{
    [TestClass]
    public class ExampleServiceTest
    {
        [TestMethod]
        public void KillExampleTest()
        {
            Example example = new Example() { Name = "Rouke", Id = 1 };

            var repoMock = new Mock<IRepository<Example, long>>(MockBehavior.Loose);
            repoMock.Setup(repo => repo.Delete(example)).Returns(1);
            repoMock.Setup(repo => repo.Find(1)).Returns(example);

            var eventHandlerMock = new Mock<IEventHandler>(MockBehavior.Loose);
            eventHandlerMock.Setup(handler => handler.Bus).Returns(new Mock<IAdvancedBus>(MockBehavior.Loose).Object);

            using (var service = new ExampleService(repoMock.Object, eventHandlerMock.Object))
            {
                var result = service.KillExample(example.Id);
                Assert.AreEqual(example.Id, result.Id);
            }
        }

        [TestMethod]
        public void CreateExampleTest()
        {
            Example example = new Example() { Name = "Rouke", Id = 1 };

            var repoMock = new Mock<IRepository<Example, long>>(MockBehavior.Loose);
            repoMock.Setup(repo => repo.Insert(example)).Returns(1);
            repoMock.Setup(repo => repo.Find(1)).Returns(example);

            var eventHandlerMock = new Mock<IEventHandler>(MockBehavior.Loose);
            eventHandlerMock.Setup(handler => handler.Bus).Returns(new Mock<IAdvancedBus>(MockBehavior.Loose).Object);

            using (var service = new ExampleService(repoMock.Object, eventHandlerMock.Object))
            {
                var result = service.CreateExample(example.Id);
                Assert.AreEqual(example.Id, result.Id);
            }
        }
    }
}
