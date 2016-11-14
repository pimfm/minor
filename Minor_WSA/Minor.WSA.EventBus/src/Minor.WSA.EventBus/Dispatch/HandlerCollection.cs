
using Minor.WSA.Common;
using System.Collections.Generic;

namespace Minor.WSA.EventBus.Dispatch
{
    public class HandlerCollection
    {
        Dictionary<string, List<DomainEventHandler>> _dictionary;

        public HandlerCollection()
        {
            _dictionary = new Dictionary<string, List<DomainEventHandler>>();
        }

        public void Add(string key, DomainEventHandler handler)
        {
            if (false == _dictionary.ContainsKey(key))
            {
                _dictionary.Add(key, new List<DomainEventHandler>() { handler });

                return;
            }

            if (false == _dictionary[key].Contains(handler)) {
                _dictionary[key].Add(handler);
            }
        }

        public IEnumerable<DomainEventHandler> Find(string key)
        {
            return _dictionary[key];
        }
    }
}
