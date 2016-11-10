using System;

namespace Minor.WSA.EventBus.Shared
{
    internal interface IChannel : IDisposable
    {
        void Publish(string exchangeName, string routingKey, byte[] body);
    }
}