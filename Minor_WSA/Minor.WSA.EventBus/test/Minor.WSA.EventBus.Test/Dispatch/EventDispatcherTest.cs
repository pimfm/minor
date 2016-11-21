using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.WSA.Common;
using Minor.WSA.EventBus.Dispatch;
using System.Collections;

namespace Minor.WSA.EventBus.Test.Dispatch
{
    [TestClass]
    public class EventDispatcherTest
    {
        [TestMethod]
        public void DispatcherCanFindAllHandlers()
        {
            // Arrange
            EventDispatcher dispatcher = new EventDispatcher();

            // Act
            dispatcher.Activate();

            // Assert
            //Assert.IsTrue(dispatcher.Handlers.Count > 0);
            //CollectionAssert.AllItemsAreInstancesOfType(dispatcher.Handlers as ICollection, typeof(IEventHandler<DomainEvent>));
        }
    }
}
