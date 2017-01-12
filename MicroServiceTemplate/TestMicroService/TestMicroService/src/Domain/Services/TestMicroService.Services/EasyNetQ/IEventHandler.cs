using EasyNetQ;
using EasyNetQ.Topology;
using System;

namespace TestMicroService.Services.EasyNetQ
{
    public interface IEventHandler
        :IDisposable
    {
        IAdvancedBus Bus { get; }
        IExchange Exchange { get;  }
        IQueue Queue { get; }
    }     
}
