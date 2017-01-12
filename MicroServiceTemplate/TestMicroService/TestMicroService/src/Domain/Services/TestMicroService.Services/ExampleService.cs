using EasyNetQ;
using System;

namespace TestMicroService.Services
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

        public Example KillExample(Example example)
        {
            _repository.Delete(example.Id);
            _handler.Bus.Publish(_handler.Exchange,
                                "RoutingKey",
                                false,
                                new Message<ExampleKilledEvent>(new ExampleKilledEvent(example)));

            return example;
        }

        public Example CreateExample(Example example)
        {

            _repository.Insert(example);
            _handler.Bus.Publish(_handler.Exchange,
                                "RoutingKey",
                                false, new Message<ExampleCreatedEvent>(new ExampleCreatedEvent(example)));
            return example;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
