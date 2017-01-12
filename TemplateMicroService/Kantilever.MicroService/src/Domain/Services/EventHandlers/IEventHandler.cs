using Kantilever.MicroService.Domain.Events;

namespace $safeprojectname$.EventHandlers
{
    public interface IEventHandler<TEvent>
        where TEvent : DomainEvent
    {
        void Handle(TEvent domainEvent);
    }
}
