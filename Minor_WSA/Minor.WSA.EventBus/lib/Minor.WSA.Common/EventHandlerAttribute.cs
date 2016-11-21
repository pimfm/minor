using System;
namespace Minor.WSA.Common
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class EventHandlerAttribute : Attribute
    {
    }
}