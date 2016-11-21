
using Minor.WSA.Common;
using System.Collections.Generic;

namespace Minor.WSA.EventBus.Dispatch
{
    public class HandlerCollection
    {
        Dictionary<string, List<IEventHandler<DomainEvent>>> _dictionary;

        public HandlerCollection()
        {
            _dictionary = new Dictionary<string, List<IEventHandler<DomainEvent>>>();
        } 

        public void Add<TEvent>(IEventHandler<TEvent> handler) where TEvent : DomainEvent
        {
            string key = "TODO";

            if (false == _dictionary.ContainsKey(key))
            {
                _dictionary.Add(key, new List<IEventHandler<DomainEvent>>() { handler });

                return;
            }

            if (false == _dictionary[key].Contains(handler)) {
                _dictionary[key].Add(handler);
            }
        }

        public IEnumerable<IEventHandler<DomainEvent>> Find(string key)
        {
            return _dictionary[key];
        }
    }
}
