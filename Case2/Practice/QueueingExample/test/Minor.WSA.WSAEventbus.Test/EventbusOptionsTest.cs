using Microsoft.VisualStudio.TestTools.UnitTesting;
using RawRabbit.Configuration;

namespace Minor.WSA.WSAEventbus.Test
{
    [TestClass]
    public class EventbusOptionsTest
    {
        [TestMethod]
        public void EventbusOptionsIsInstanceOfRawRabbitConfiguration()
        {
            // Arrange
            EventbusOptions options = new EventbusOptions();

            // Assert
            Assert.IsInstanceOfType(options, typeof(RawRabbitConfiguration));
        }

        [TestMethod]
        public void InitializingEventbusOptionsWithoutParamsGivesDefaultConfiguration()
        {
            // Arrange
            EventbusOptions options = new EventbusOptions();

            // Act
            string username = options.Username;
            int port = options.Port;
            string exchangeName = options.ExchangeName;

            // Assert
            Assert.AreEqual("guest", username);
            Assert.AreEqual(5672, port);
            Assert.AreEqual("Minor.WSA.WSAEventbus", exchangeName);
        }

        [TestMethod]
        public void ASubsetOfConfigurationCanBeChangedAndRestWillStayOnDefault()
        {
            // Arrange
            string otherUsername = "Admin";
            EventbusOptions options = new EventbusOptions(username : otherUsername);

            // Act
            string username = options.Username;
            int port = options.Port;
            string exchangeName = options.ExchangeName;

            // Assert
            Assert.AreEqual("Admin", username);
            Assert.AreEqual(5672, port);
            Assert.AreEqual("Minor.WSA.WSAEventbus", exchangeName);
        }
    }
}
