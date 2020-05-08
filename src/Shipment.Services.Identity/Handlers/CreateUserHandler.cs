using System;
using Shipment.Common.Commands;
using Shipment.Common.Events;
using System.Threading.Tasks;
using RawRabbit;
using Shipment.Services.Identity.Services;
using Shipment.Common.Exceptions;
// using Microsoft.Extensions.Logging;

namespace Shipment.Services.Identity.Handlers
{
     public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IBusClient _busClient;
        private readonly IUserService _userService;
        // private ILogger _logger;

        public CreateUserHandler(IBusClient busClient, IUserService userService){
            _userService = userService;
            _busClient = busClient;
            // _logger = logger;
        }


        public async Task HandleAsync(CreateUser user)
        {                        
            Console.WriteLine($"Creating USer: {user.Email}");

            try{
                await _userService.RegisterAsync(user.Email, user.Password, user.Name);
                await _busClient.PublishAsync(new UserCreated(user.Email, user.Name));
                Console.WriteLine($"User Created {user.Email}!");
                return;
            }
            catch(ShipmentException ex){
                await _busClient.PublishAsync(new CreateUserRejected(user.Email, ex.Code, ex.Message));
                // _logger.LogError(ex.Message);
                Console.WriteLine(ex.Message);

            }

            // await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category, command.Name,command.Description, command.CreatedAt));
        }
    }
}