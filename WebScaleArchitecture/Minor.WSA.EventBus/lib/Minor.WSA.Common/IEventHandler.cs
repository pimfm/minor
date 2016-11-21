namespace Minor.WSA.Common
{
    public interface IEventHandler<T>
        where T : DomainEvent
    {
        void Handle(T domainEvent);
    }
}
