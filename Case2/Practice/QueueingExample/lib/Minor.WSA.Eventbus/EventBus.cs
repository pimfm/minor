using System;
using Minor.WSA.Common.Contracts;
using Minor.WSA.Common.Domain;
using RawRabbit.vNext;
using RawRabbit.vNext.Disposable;
using System.Threading.Tasks;
using RawRabbit.Configuration.Subscribe;
using RawRabbit.Configuration.Publish;

namespace Minor.WSA.Eventbus
{
    public class EventBus : IEventbus
    {
        private EventBusOptions _options;
        private IBusClient _busClient; 

        public EventBus(EventBusOptions options = null)
        {
            _options = options ?? new EventBusOptions();
            _busClient = BusClientFactory.CreateDefault(_options);
        }

        public async Task PublishEvent<TEvent>(TEvent domainEvent) where TEvent : DomainEvent
        {
            await _busClient.PublishAsync(domainEvent, domainEvent.Guid, ProvidePublisherConfiguration<TEvent>());
        }

        public async Task PublishCommand<TCommand>(TCommand domainCommand) where TCommand : DomainCommand
        {
            await _busClient.PublishAsync(domainCommand, domainCommand.Guid, ProvidePublisherConfiguration<TCommand>());
        }

        public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : DomainEvent
        {
            _busClient.SubscribeAsync<TEvent>(async (message, context) => await eventHandler.Handle(message), ProvideSubscriberConfiguration<TEvent>());
        }

        public void Subscribe<TCommand>(ICommandHandler<TCommand> commandHandler) where TCommand : DomainCommand
        {
            _busClient.SubscribeAsync<TCommand>(async (message, context) => await commandHandler.Handle(message), ProvideSubscriberConfiguration<TCommand>());
        }

        public void Dispose()
        {
            _busClient?.Dispose();
        }

        private Action<IPublishConfigurationBuilder> ProvidePublisherConfiguration<T>()
        {
            return configurationBuilder =>
            {
                configurationBuilder.WithExchange(exchange => exchange.WithName(_options.ExchangeName))
                                    .WithRoutingKey(GenerateRoutingKey<T>());
            };
        }

        private Action<ISubscriptionConfigurationBuilder> ProvideSubscriberConfiguration<T>()
        {
            return configurationBuilder =>
            {
                configurationBuilder.WithExchange(exchange => exchange.WithName(_options.ExchangeName))
                                    .WithRoutingKey(GenerateRoutingKey<T>());
            };
        }

        private string GenerateRoutingKey<T>()
        {
            return typeof(T).Namespace + typeof(T).Name;
        }
    }
}
