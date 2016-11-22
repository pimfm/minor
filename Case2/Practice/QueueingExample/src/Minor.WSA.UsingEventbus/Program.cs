using Minor.WSA.Common.Contracts;
using Minor.WSA.UsingEventbus.Events;
using Minor.WSA.UsingEventbus.Events.Handlers;
using Minor.WSA.WSAEventbus;

namespace Minor.WSA.UsingEventbus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IEventbus eventBus = new Eventbus();
            eventBus.Subscribe(new RoomCreatedHandler());
            eventBus.PublishEvent(new RoomCreatedEvent());
        }
    }
}
