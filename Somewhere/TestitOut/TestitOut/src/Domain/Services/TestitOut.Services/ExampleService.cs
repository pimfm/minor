using Bagagedrager.Common.Events;
using EasyNetQ;
using System;
using TestitOut.Entities;
using TestitOut.Services.EasyNetQ;
using System.Threading.Tasks;

namespace TestitOut.Services
{
    public class ExampleService : IDisposable
    {
        private readonly IRepository<Example, int> _repository;
        private readonly IEventHandler _handler;

        public ExampleService(IRepository<Example, int> repository, IEventHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        public Example CreateExample(Example example)
        {

            _repository.Insert(example);
            _handler.Bus.Publish(_handler.Exchange,
                                "RoutingKey",
                                false, new Message<ExampleEvent>(new ExampleEvent()));
            return example;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public Task Handle(ExampleEvent body)
        {
            //do all the stuffz
            return null;
        }
    }
}
