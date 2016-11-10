using Minor.WSA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Minor.WSA.EventBus.Dispatch
{
    public class EventDispatcher
    {
        public Dictionary<string, object> Handlers { get; private set; }

        public EventDispatcher()
        {
            Handlers = new Dictionary<string, object>();
        }

        public void Activate()
        {
            Assembly assembly = Assembly.Load(new AssemblyName("Minor.WSA.EventBus.Test"));
            foreach (Type type in assembly.GetTypes())
            {
                foreach (MethodInfo method in type.GetMethods())
                {
                    if (method.GetCustomAttributes<EventHandlerAttribute>().Count() > 0)
                    {
                        Type eventType = method.GetParameters().First().ParameterType;

                        Handlers.Add(eventType.Name, Activator.CreateInstance(type));
                    }
                }
            }
            // Find all handlers
            // Store in internal dictionary/list
            // Consume events
            // Fire right handler
        }
    }
}
