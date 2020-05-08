using RawRabbit;
using Shipment.Common.Commands;
using Shipment.Common.Events;
using Shipment.Common.Exceptions;
using System;
using System.Threading.Tasks;
using Shipment.Services.Activities.Services;


namespace Shipment.Services.Activities.Handlers
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {

        private readonly IBusClient _busClient;
        private readonly IActivityService _activityService;

        public CreateActivityHandler(IBusClient busClient, IActivityService activityService)
        {
            _busClient = busClient;
            _activityService = activityService;
        }
        
        public async Task HandleAsync(CreateActivity command)
        {                        
            Console.WriteLine($"Create Activity: {command.Name}");
            try{
                await _activityService.AddAsync(command.Id, 
                command.UserId, command.Category, command.Name, command.Description, command.CreatedAt);
                 await _busClient.PublishAsync(new ActivityCreated(command.Id, 
                command.UserId, command.Category, command.Name, command.Description, command.CreatedAt));
                Console.WriteLine($"Activity Created: {command.Name}");
                return;
            }catch(ShipmentException ex){
                Console.WriteLine(ex.Message);
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, 
                    ex.Code, ex.Message
                ));
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, 
                    "error", ex.Message
                ));
            }
           
        }
    }
}
