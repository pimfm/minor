using Minor.WSA.Common.Domain;
using System.Threading.Tasks;

namespace Minor.WSA.Common.Contracts
{
    /// <summary>
    ///     Use a handler to subscribe to an event
    ///     and implement the handle method to add
    ///     functionality to when the event is fired.
    /// </summary>
    /// <example>
    ///     public class RoomCreatedHandler : IEventHandler<RoomCreatedEvent>
    /// </example>
    /// <typeparam name="TEvent"></typeparam>
    public interface IEventHandler<TEvent>
        where TEvent : DomainEvent
    {
        /// <summary>
        ///     Add functionality to a triggered event
        /// </summary>
        /// <param name="domainCommand"></param>
        /// <returns></returns>
        Task Handle(TEvent domainEvent);
    }
}
