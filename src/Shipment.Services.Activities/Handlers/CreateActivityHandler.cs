using Shipment.Common.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipment.Services.Activities.Handlers
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {

        private readonly IBusClient _busClient;
        
        public async Task HandleAsync(CreateActivity command)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Create Activity: {command.Name}");
        }
    }
}
