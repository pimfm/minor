using EasyNetQ;
using EasyNetQ.Topology;

namespace TestMicroService.Services.EasyNetQ
{
    public class EventHandler
        : IEventHandler
    {
        private IAdvancedBus _bus;
        private IExchange _exchange;
        private IQueue _queue;

        public EventHandler(string host)
        {
            _bus = RabbitHutch.CreateBus($"host={host}").Advanced;
            if (_bus.IsConnected)
            {
                _exchange = _bus.ExchangeDeclare("my-bus", "topic", durable: false);
                _queue = _bus.QueueDeclare("example");
            }
        }

        public IAdvancedBus Bus
        {
            get
            {
                return _bus;
            }
        }

        public IExchange Exchange
        {
            get
            {
                return _exchange;
            }
        }

        public IQueue Queue
        {
            get
            {
                return _queue;
            }
        }

        public void Dispose()
        {
            _bus?.Dispose();
        }
    }
}
