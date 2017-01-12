using Kantilever.MicroService.Domain.Events;

namespace Kantilever.MicroService.DomainServices.EventHandlers
{
    public interface IEventHandler<TEvent>
        where TEvent : DomainEvent
    {
        void Handle(TEvent domainEvent);
    }
}
