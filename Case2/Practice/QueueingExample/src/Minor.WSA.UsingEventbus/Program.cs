
using Minor.WSA.Common.Contracts;

namespace Minor.WSA.UsingEventbus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IEventbus eventBus = new Eventbus();
        }
    }
}
