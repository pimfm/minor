
using Minor.WSA.EventBus.Test.Handlers;

namespace Minor.WSA.EventBus.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EventBus eventBus = new EventBus();
            eventBus.Subscribe(new RoomCreatedHandler());
        }
    }
}
