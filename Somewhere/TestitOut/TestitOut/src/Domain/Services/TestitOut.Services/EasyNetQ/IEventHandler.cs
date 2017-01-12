using EasyNetQ;
using EasyNetQ.Topology;
using System;

namespace TestitOut.Services.EasyNetQ
{
    public interface IEventHandler
        :IDisposable
    {
        IAdvancedBus Bus { get; }
        IExchange Exchange { get;  }
        IQueue Queue { get; }
    }     
}
