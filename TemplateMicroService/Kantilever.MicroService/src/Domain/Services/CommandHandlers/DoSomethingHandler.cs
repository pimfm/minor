using System;
using EasyNetQ;
using Kantilever.MicroService.Domain.Commands;
using Kantilever.MicroService.Domain.Events;
using $safeprojectname$.Contracts;

namespace $safeprojectname$.CommandHandlers
{
    public class DoSomethingHandler  : 
        ICommandHandler<DoSomething>,
        ICommandHandler<DoSomethingElse>
    {
        private IMessageBus _messageBus;

        public DoSomethingHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public void Handle(DoSomethingElse command)
        {
            Console.WriteLine("Look Pa, I did something else!");

            _messageBus.Publish(new SomethingElseIsDone());
        }

        public void Handle(DoSomething command)
        {
            Console.WriteLine("Look Ma, I did something!");

            _messageBus.Publish(new SomethingIsDone());
        }
    }
}
