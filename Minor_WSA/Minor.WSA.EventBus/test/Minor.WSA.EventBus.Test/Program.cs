using Minor.WSA.Common;
using Minor.WSA.EventBus.Dispatch;

namespace Minor.WSA.EventBus.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EventDispatcher dispatcher = new EventDispatcher();
            dispatcher.Activate();

            foreach (var pair in dispatcher.Handlers)
            {
                System.Console.WriteLine($"{pair.Value.GetType()}({pair.Key})");
            }
        }
    }
}
