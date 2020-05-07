using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;
using Shipment.Common.Commands;
using Shipment.Common.Events;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Common.RabbitMq
{
    public static class Extensions
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseConsumerConfiguration(cfg =>
                    cfg.FromDeclaredQueue(Queue => Queue.WithName(GetQueueName<TCommand>()))));


        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
           IEventHandler<TEvent> handler) where TEvent : IEvent
           => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
               ctx => ctx.UseConsumerConfiguration(cfg =>
                   cfg.FromDeclaredQueue(Queue => Queue.WithName(GetQueueName<TEvent>()))));


        private static string GetQueueName<T>()
            => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";


        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });
            services.AddSingleton<IBusClient>(_ => client);
        }
    }

}
