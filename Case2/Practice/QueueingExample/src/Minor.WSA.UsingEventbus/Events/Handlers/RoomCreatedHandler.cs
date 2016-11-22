using Minor.WSA.Common.Contracts;
using System;
using System.Threading.Tasks;

namespace Minor.WSA.UsingEventbus.Events.Handlers
{
    public class RoomCreatedHandler : IEventHandler<RoomCreatedEvent>
    {
        public Task Handle(RoomCreatedEvent domainEvent)
        {
            return new Task(() => Console.WriteLine($"{domainEvent.Timestamp} - {domainEvent.Guid}"));
        }
    }
}
