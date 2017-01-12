
using System;
using EasyNetQ;
using EasyNetQ.Topology;
using Kantilever.MicroService.DomainServices.Contracts;

namespace $safeprojectname$.Messaging
{
    public class MessageBus : IMessageBus
    {
        private IAdvancedBus _bus;
        private IExchange _exchange;

        public MessageBus(IAdvancedBus bus)
        {
            _bus = bus;
            _exchange = bus.ExchangeDeclare("Kantilever.Webshop", ExchangeType.Topic);
        }

        public void Publish<TMessage>(TMessage message) where TMessage : class
        {
            _bus.Publish(_exchange, typeof(TMessage).FullName, false, new Message<TMessage>(message));
        }

        public void Subscribe<TMessage>(Action<TMessage> handlerAction) where TMessage : class
        {
            string routingKey = typeof(TMessage).FullName;
            IQueue queue = _bus.QueueDeclare(routingKey);

            _bus.Bind(_exchange, queue, routingKey);
            _bus.Consume<TMessage>(queue, (message, info) => handlerAction(message.Body));
        }
    }
}
