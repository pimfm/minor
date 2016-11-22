using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.WSA.Common.Contracts;
using Minor.WSA.WSAEventbus.Test.Events;
using Minor.WSA.WSAEventbus.Test.Events.Handlers;
using System;

namespace Minor.WSA.WSAEventbus.Test
{
    [TestClass]
    public class EventbusTest
    {
        [TestMethod]
        public void EventBusImplementsDomainContractAndIDisposable()
        {
            // Arrange
            Eventbus eventbus = new Eventbus();

            // Assert
            Assert.IsInstanceOfType(eventbus, typeof(IEventbus));
            Assert.IsInstanceOfType(eventbus, typeof(IDisposable));
        }

        [TestMethod]
        public void EventPublishingAndHandlingTest()
        {
            // Arrange
            EventbusOptions options = new EventbusOptions(exchangeName: "Minor.WSA.WSAEventbus.Test");
            Eventbus eventbus = new Eventbus(options);
            RoomCreatedEvent domainEvent = new RoomCreatedEvent("room42");
            RoomCreatedHandler eventHandler = new RoomCreatedHandler();

            // Act
            eventbus.Subscribe(eventHandler);
            eventbus.PublishEvent(domainEvent);

            // Assert
            Assert.AreEqual(1, eventHandler.HandleCalledCount);
        }
    }
}
