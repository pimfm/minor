using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Minor.WSA.EventBus.Shared;

namespace Minor.WSA.EventBus.Dispatch
{
    public abstract class EventDispatcher : IDisposable
    {
        private Channel _channel;
        private EventBusOptions _eventBusOptions;
        private Dictionary<string, MethodObject> _methods;

        public EventDispatcher(EventBusOptions options = null)
        {
            var routingKey = GetType.GetTypeInfo().GetCustomAttributes<RoutingKeyAttribute>().FirstOrDefault()?.Topic ?? "#";
            _eventBusOptions = options ?? new EventBusOptions();
            _channel = new Channel(_eventBusOptions);

            _channel.ExchangeDeclare(_busOptions.ExchangeName, ExchangeType.Topic);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _queueName, exchange: _busOptions.ExchangeName, routingKey: routingKey);

            SetupMethodInfo();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += OnReceivedEvent;
            _channel.BasicConsume(queue: _queueName, noAck: true, consumer: consumer);

            // Reflection store each method with it's parameter
        }

        private void SetupMethodInfo()
        {
            var type = this.GetType();
            _methods = new Dictionary<string, MethodObject>();
            foreach (var method in type.GetMethods())
            {
                var parameters = method.GetParameters();
                if (parameters.Count() > 1)
                {
                    continue;
                }

                foreach (var parameter in parameters)
                {
                    if ((typeof(DomainEvent)).IsAssignableFrom(parameter.ParameterType))
                    {

                        try
                        {
                            _methods.Add(parameter.ParameterType.FullName, new MethodObject { type = parameter.ParameterType, methodInfo = method });
                        }
                        catch (ArgumentException)
                        {
                            throw new DuplicateMethodWithSameEventParameterException(method.ToString());
                        }
                    }
                }
            }
        }

        protected virtual void OnReceivedEvent(object sender, BasicDeliverEventArgs e)
        {
            var typeEvent = e.BasicProperties.Type;
            var KeyValuePair = _methods.First(k => k.Key == typeEvent);

            var MethodObject = KeyValuePair.Value;

            var message = Encoding.UTF8.GetString(e.Body);
            var domainEvent = JsonConvert.DeserializeObject(message, MethodObject.type);
            MethodObject.methodInfo.Invoke(this, new object[] { domainEvent });
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }
    }
}
