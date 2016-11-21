using Minor.WSA.Common.Domain;
using System;
using System.Threading.Tasks;

namespace Minor.WSA.Common.Contracts
{
    public interface IEventbus : IDisposable
    {
        Task PublishEvent<TEvent>(TEvent domainEvent) where TEvent : DomainEvent;
        Task PublishCommand<TCommand>(TCommand domainCommand) where TCommand : DomainCommand;
        void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : DomainEvent;
        void Subscribe<TCommand>(ICommandHandler<TCommand> commandHandler) where TCommand : DomainCommand;
    }
}
