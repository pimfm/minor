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
    }
}
