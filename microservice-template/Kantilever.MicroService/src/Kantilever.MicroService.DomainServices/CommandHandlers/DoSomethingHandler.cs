using System;
using EasyNetQ;
using Kantilever.MicroService.Domain.Commands;
using Kantilever.MicroService.Domain.Events;
using Kantilever.MicroService.DomainServices.Contracts;

namespace Kantilever.MicroService.DomainServices.CommandHandlers
{
    public class DoSomethingHandler : ICommandHandler<DoSomething>
    {
        private IMessageBus _messageBus;

        public DoSomethingHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public void Handle(DoSomething command)
        {
            Console.WriteLine("Look Ma, I did something!");

            _messageBus.Publish(new SomethingIsDone());
        }
    }
}
