
using Shipment.Common.Events;
using Shipment.Common.Services;

namespace Shipment.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToEvent<ActivityCreated>()
                .Build()
                .Run();
        }
    }
}
