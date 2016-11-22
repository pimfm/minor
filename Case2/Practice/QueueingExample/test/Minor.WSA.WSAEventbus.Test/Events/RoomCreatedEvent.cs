using Minor.WSA.Common.Domain;

namespace Minor.WSA.WSAEventbus.Test.Events
{
    public class RoomCreatedEvent : DomainEvent
    {
        public readonly string RoomName;

        public RoomCreatedEvent(string roomName)
        {
            RoomName = roomName;
        }
    }
}
