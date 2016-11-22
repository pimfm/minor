using System;
using Minor.WSA.Common.Contracts;
using Minor.WSA.Common.Domain;
using RawRabbit.vNext;
using RawRabbit.vNext.Disposable;
using System.Threading.Tasks;
using RawRabbit.Configuration.Subscribe;
using RawRabbit.Configuration.Publish;

namespace Minor.WSA.WSAEventbus
{
    /// <summary>
    ///     The facade class for communicating
    ///     with the eventbus, contains methods for 
    ///     publishers and subscribers and is the only 
    ///     class ever needed when injecting services
    ///     related to the message queue.
    /// </summary>
    /// <example>
    ///     EventbusOptions options = new EventbusOptions(Port = 1337);
    ///     IEventbus eventbus = new Eventbus(options);
    /// </example>
    public class Eventbus : IEventbus
    {
        /// <summary>
        ///     Configuration of the eventbus
        ///     such as username and exchange name
        /// </summary>
        private EventbusOptions _options;

        /// <summary>
        ///     The internally used rawrabbit eventbus
        /// </summary>
        private IBusClient _busClient; 

        public Eventbus(EventbusOptions options = null)
        {
            _options = options ?? new EventbusOptions();
            _busClient = BusClientFactory.CreateDefault(_options);
        }

        /// <summary>
        ///     Send an event to the exchange to tell 
        ///     event subscribers something has happened
        /// </summary>
        /// <example>
        ///     IEventbus eventbus = new Eventbus();
        ///     eventbus.PublishEvent(new RoomCreatedEvent());
        /// </example>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="domainEvent"></param>
        /// <returns></returns>
        public async Task PublishEvent<TEvent>(TEvent domainEvent) where TEvent : DomainEvent
        {
            await _busClient.PublishAsync(domainEvent, domainEvent.Guid, ProvidePublisherConfiguration<TEvent>());
        }

        /// <summary>
        ///     Send a command to the exchange 
        ///     to tell command subscribers what to do
        /// </summary>
        /// <example>
        ///     IEventbus eventbus = new Eventbus();
        ///     eventbus.PublishCommand(new CreateRoomCommand());
        /// </example>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="domainCommand"></param>
        /// <returns></returns>
        public async Task PublishCommand<TCommand>(TCommand domainCommand) where TCommand : DomainCommand
        {
            await _busClient.PublishAsync(domainCommand, domainCommand.Guid, ProvidePublisherConfiguration<TCommand>());
        }

        /// <summary>
        ///     Listen to a certain event by coupling an event
        ///     handler that can handle that specific event
        /// </summary>
        /// <example>
        ///     IEventbus eventbus = new Eventbus();
        ///     eventbus.Subscribe(new RoomCreatedHandler());
        /// </example>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="eventHandler"></param>
        public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : DomainEvent
        {
            _busClient.SubscribeAsync<TEvent>(async (message, context) => await eventHandler.Handle(message), ProvideSubscriberConfiguration<TEvent>());
        }

        /// <summary>
        ///     Listen to a command that requires you to 
        ///     take action by setting up a command handler
        ///     that knows how to handle the instruction
        /// </summary>
        /// <example>
        ///     IEventbus eventbus = new Eventbus();
        ///     eventbus.Subscribe(new CreateRoomHandler());
        /// </example>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="commandHandler"></param>
        public void Subscribe<TCommand>(ICommandHandler<TCommand> commandHandler) where TCommand : DomainCommand
        {
            _busClient.SubscribeAsync<TCommand>(async (message, context) => await commandHandler.Handle(message), ProvideSubscriberConfiguration<TCommand>());
        }

        /// <summary>
        ///     Cleanup unmanaged resources
        /// </summary>
        public void Dispose()
        {
            _busClient?.Dispose();
        }

        /// <summary>
        ///     Compose a configuration builder 
        ///     about publisher configuration
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private Action<IPublishConfigurationBuilder> ProvidePublisherConfiguration<T>()
        {
            return configurationBuilder =>
            {
                configurationBuilder.WithExchange(exchange => exchange.WithName(_options.ExchangeName))
                                    .WithRoutingKey(GenerateRoutingKey<T>());
            };
        }

        /// <summary>
        ///     Compose a configuration builder
        ///     about subscriber configuration
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private Action<ISubscriptionConfigurationBuilder> ProvideSubscriberConfiguration<T>()
        {
            return configurationBuilder =>
            {
                configurationBuilder.WithExchange(exchange => exchange.WithName(_options.ExchangeName))
                                    .WithRoutingKey(GenerateRoutingKey<T>());
            };
        }

        /// <summary>
        ///     Use the namespace and type name
        ///     to generate a routing key
        ///     unique to this event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private string GenerateRoutingKey<T>()
        {
            return $"{typeof(T).Namespace}.{typeof(T).Name}";
        }
    }
}
