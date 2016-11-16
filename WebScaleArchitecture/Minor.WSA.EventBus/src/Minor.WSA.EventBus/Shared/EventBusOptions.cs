namespace Minor.WSA.EventBus.Shared
{
    public class EventBusOptions
    {
        public readonly string Host;
        public readonly string ExchangeName;

        public EventBusOptions(string host, string exchangeName)
        {
            Host = host;
            ExchangeName = exchangeName;
        }

        public EventBusOptions()
        {
            Host = "localhost";
            ExchangeName = "Minor.WSA.BKEEventBus";
        }
    }
}
