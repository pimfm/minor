using System;

namespace Minor.WSA.EventBus
{
    public interface IChannel : IDisposable
    {
        void Publish()
    }
}