using Minor.WSA.Common.Domain;
using System;
using System.Threading.Tasks;

namespace Minor.WSA.Common.Contracts
{
    public interface IEventbus : IDisposable
    {
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
        Task PublishEvent<TEvent>(TEvent domainEvent) where TEvent : DomainEvent;

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
        Task PublishCommand<TCommand>(TCommand domainCommand) where TCommand : DomainCommand;

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
        void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : DomainEvent;

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
        void Subscribe<TCommand>(ICommandHandler<TCommand> commandHandler) where TCommand : DomainCommand;
    }
}
