
using System;
using Minor.WSA.Common;
using Minor.WSA.EventBus.Test.Events;

namespace Minor.WSA.EventBus.Test.Handlers
{
    public class RoomCreatedHandler : DomainEventHandler<RoomCreatedEvent>
    {
        public override void Handle(RoomCreatedEvent domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
