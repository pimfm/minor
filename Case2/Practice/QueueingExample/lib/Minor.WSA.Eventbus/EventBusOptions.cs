using RawRabbit.Configuration;
using System.Collections.Generic;

namespace Minor.WSA.Eventbus
{
    /// <summary>
    /// A value object containing all configuration shared by 
    /// event publishers and subscribers. It allows for 
    /// easy injection of correct configuration.
    /// </summary>
    public class EventBusOptions : RawRabbitConfiguration
    {
        /// <summary>
        /// A default implementation of the bus options
        /// it contains the standard values to
        /// allow using the queue without manual configuration
        /// </summary>
        public EventBusOptions()
        {
            Username = "guest";
            Password = "guest";
            Port = 5672;
            Hostnames = new List<string>(){ "localhost" };
            VirtualHost = "/";
        }

        /// <summary>
        /// A detailed constructor, where every parameter
        /// can be configured and uses the standard
        /// values as a default.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="port"></param>
        /// <param name="hostName"></param>
        /// <param name="virtualHost">namespace for objects like Exchanges, Queues and Bindings</param>
        public EventBusOptions(
            string username = "guest",
            string password = "guest",
            int port = 5672,
            string hostName = "localhost",
            string virtualHost = "/"
        )
        {
            Username = username;
            Password = password;
            Port = port;
            VirtualHost = virtualHost;
            Hostnames = new List<string>() { hostName };
        }
    }
}