using Minor.WSA.Common.Domain;
using System.Threading.Tasks;

namespace Minor.WSA.Common.Contracts
{
    public interface IEventHandler<TEvent>
        where TEvent : DomainEvent
    {
        Task Handle(TEvent domainEvent);
    }
}
