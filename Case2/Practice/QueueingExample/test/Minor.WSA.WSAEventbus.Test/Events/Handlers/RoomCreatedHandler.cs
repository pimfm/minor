using Minor.WSA.Common.Contracts;

namespace Minor.WSA.WSAEventbus.Test.Events.Handlers
{
    public class RoomCreatedHandler : IEventHandler<RoomCreatedEvent>
    {
        public int HandleCalledCount { get; private set; }

        public void Handle(RoomCreatedEvent domainEvent)
        {
            HandleCalledCount++;
        }
    }
}
