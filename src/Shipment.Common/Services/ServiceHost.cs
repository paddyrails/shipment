using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using RawRabbit;
using Shipment.Common.Commands;
using Shipment.Common.Events;
using Shipment.Common.RabbitMq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipment.Common.Services
{
    public class ServiceHost : IServiceHost
    {
        private readonly IWebHost _webHost;

        public ServiceHost(IWebHost webHost)
        {
            _webHost = webHost;
        }

        public void Run() => _webHost.Run();

        public static HostBuilder Create<TStartup>(string[] args) where TStartup : class
        {
            Console.Title = typeof(TStartup).Namespace;
            var config = new ConfigurationBuilder()
                    .AddEnvironmentVariables()
                    .AddCommandLine(args)
                    .Build();
            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseStartup<TStartup>();

            return new HostBuilder(webHostBuilder.Build());
        }

        public abstract class BuilderBase
        {
            public abstract ServiceHost Build();
        }

        public class HostBuilder : BuilderBase
        {
            private readonly IWebHost _webhost;
            private IBusClient _bus;
            public HostBuilder(IWebHost webHost, IBusClient busClient)
            {
                _webhost = webHost;
                _bus = busClient;
            }

            public BusBuilder UseRabbitMq()
            {
                _bus = (IBusClient)_webhost.Services.GetService(typeof(IBusClient));
                return new BusBuilder(_webhost, _bus);
                     
            }

            public override ServiceHost Build()
            {
                throw new NotImplementedException();
            }

            
        }

        public class BusBuilder : BuilderBase
        {
            private readonly IWebHost _webhost;
            private IBusClient _bus;
            public BusBuilder(IWebHost webHost, IBusClient bus)
            {
                _webhost = webHost;
                _bus = bus;
            }

            public BusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
            {
                var handler = (ICommandHandler<TCommand>)_webhost.Services
                       .GetService(typeof(ICommandHandler<TCommand>));
                _bus.WithCommandHandlerAsync(handler);

                return this;
            }

            public BusBuilder SubscribeToEvent<TEvent>() where TEvent: IEvent
            {
                var handler = (ICommandHandler<TEvent>)_webhost.Services
                       .GetService(typeof(ICommandHandler<TEvent>));
                _bus.WithEventHandlerAsync(handler);

                return this;
            }

            public override ServiceHost Build()
            {
                throw new NotImplementedException();
            }
        }


    }
}
