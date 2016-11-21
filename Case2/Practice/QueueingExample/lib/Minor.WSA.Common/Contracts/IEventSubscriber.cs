namespace Minor.WSA.Common.Contracts
{
    public interface IEventSubscriber
    {
        void Subscribe<TEvent>(/*TODO: handler of event*/);
    }
}