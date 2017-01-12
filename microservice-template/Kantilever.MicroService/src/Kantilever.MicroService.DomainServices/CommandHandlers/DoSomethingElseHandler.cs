using System;
using EasyNetQ;
using Kantilever.MicroService.Domain.Commands;
using Kantilever.MicroService.Domain.Events;
using Microsoft.Extensions.Logging;
using Kantilever.MicroService.DomainServices.Contracts;

namespace Kantilever.MicroService.DomainServices.CommandHandlers
{
    public class DoSomethingElseHandler : ICommandHandler<DoSomethingElse>
    {
        private IMessageBus _messageBus;

        public DoSomethingElseHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public void Handle(DoSomethingElse command)
        {
            Console.WriteLine("Look Pa, I did something else!");

            _messageBus.Publish(new SomethingElseIsDone());
        }
    }
}
