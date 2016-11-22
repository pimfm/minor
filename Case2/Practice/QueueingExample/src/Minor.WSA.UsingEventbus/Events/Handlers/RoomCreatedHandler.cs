using Minor.WSA.Common.Contracts;
using System;

namespace Minor.WSA.UsingEventbus.Events.Handlers
{
    public class RoomCreatedHandler : IEventHandler<RoomCreatedEvent>
    {
        public void Handle(RoomCreatedEvent domainEvent)
        {
           Console.WriteLine($"Handling event... {domainEvent.GetType().Name}");
        }
    }
}
