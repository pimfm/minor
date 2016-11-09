namespace Minor.WSA.Common
{
    public interface IEventPublisher
    {
        void Publish(DomainEvent domainEvent);
    }
}
