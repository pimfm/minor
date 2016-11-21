
using System;
using Minor.WSA.EventBus.Test.Events;
using Minor.WSA.Common;

namespace Minor.WSA.EventBus.Test.Handlers
{
    public class RoomCreatedHandler : IEventHandler<RoomCreatedEvent>
    {
        public void Handle(RoomCreatedEvent domainEvent)
        {
            Console.WriteLine("Handle RoomcreatedEvent");
        }
    }
}
