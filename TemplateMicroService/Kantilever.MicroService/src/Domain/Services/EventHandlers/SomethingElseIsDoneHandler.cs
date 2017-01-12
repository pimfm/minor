using System;
using Kantilever.MicroService.Domain.Events;

namespace $safeprojectname$.EventHandlers
{
    public class SomethingElseIsDoneHandler : 
        IEventHandler<SomethingElseIsDone>,
        IEventHandler<SomethingIsDone>
    {
        public void Handle(SomethingIsDone domainEvent)
        {
            Console.WriteLine("Ah men, I'm so glad something else is done!");
        }

        public void Handle(SomethingElseIsDone domainEvent)
        {
            Console.WriteLine("Ah men, I'm so glad something else is done!");
        }
    }
}
