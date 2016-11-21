using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.WSA.Common;
using Minor.WSA.EventBus.Publish;
using Minor.WSA.EventBus.Shared;
using Minor.WSA.EventBus.Test.Events;
using Moq;

namespace Minor.WSA.EventBus.Test.Publish
{
    [TestClass]
    public class EventPublisherTest
    {
        [TestMethod]
        public void PublisherCanBeInstantiated()
        {
            // Arrange
            EventBusOptions options = new EventBusOptions("localhost", "BKEEventBusTest");
            IEventPublisher publisher = new EventPublisher(options);

            // Assert
            Assert.IsInstanceOfType(publisher, typeof(EventPublisher));
        }

        [TestMethod]
        public void PublisherCanPublishToRealQueue()
        {
            // Arrange
            DomainEvent domainEvent = new RoomCreatedEvent();
            EventBusOptions options = new EventBusOptions("localhost", "BKEEventBusTest");

            // Act
            using (IEventPublisher publisher = new EventPublisher(options))
            {
                publisher.Publish(domainEvent);
            }

            // TODO: Assert item in queue
            Assert.IsTrue(false);
        }
    }
}
