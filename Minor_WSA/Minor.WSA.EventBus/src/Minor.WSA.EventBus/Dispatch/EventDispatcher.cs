using Minor.WSA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Minor.WSA.EventBus.Dispatch
{
    public class EventDispatcher
    {
        public HandlerCollection _handlerCollection;

        public EventDispatcher()
        {
            _handlerCollection = new HandlerCollection();
        }
     
        public void Activate()
        {
            Assembly assembly = Assembly.Load(new AssemblyName("Minor.WSA.EventBus.Test"));
            foreach (Type type in assembly.GetTypes())
            {
                foreach (MethodInfo method in FindMethodsWithHandlerAttribute(type))
                {
                    // ---------------------------------------------------------------------

                    Type eventParameterType  = method.GetParameters().First().ParameterType;

                    _handlerCollection.Add(eventParameterType.Name, (DomainEventHandler) Activator.CreateInstance(type));

                    //----------------------------------------------------------------------
                }
            }

            // Find all handlers
            // Store in internal dictionary/list
            // Consume events
            // Fire right handler
        }

        private IEnumerable<MethodInfo> FindMethodsWithHandlerAttribute(Type type)
        {
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            return methods.Where(method => method.GetCustomAttributes<EventHandlerAttribute>().Any());
        }
    }
}
