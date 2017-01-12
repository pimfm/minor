using System;
using Kantilever.MicroService.Domain.Events;

namespace Kantilever.MicroService.DomainServices.EventHandlers
{
    public class SomethingElseIsDoneHandler : IEventHandler<SomethingElseIsDone>
    {
        public void Handle(SomethingElseIsDone domainEvent)
        {
            Console.WriteLine("Ah men, I'm so glad something else is done!");
        }
    }
}
