namespace Minor.WSA.EventBus.Shared
{
    public struct EventBusOptions
    {
        public readonly string Host;
        public readonly string ExchangeName;

        public EventBusOptions(string host, string exchangeName)
        {
            Host = host;
            ExchangeName = exchangeName;
        }
    }
}
