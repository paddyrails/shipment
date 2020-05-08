using System;
using System.Threading.Tasks;
// using Shipment.Api.Models;
// using Shipment.Api.Repositories;
using Shipment.Common.Events;

namespace Shipment.Api.Handlers
{
    public class UserCreatedHandler : IEventHandler<UserCreated>
    {
        // private readonly IActivityRepository _repository;

        // public ActivityCreatedHandler(IActivityRepository repository)
        // {
        //     _repository = repository;
        // }

        // public async Task HandleAsync(ActivityCreated @event)
        // {
        //     await _repository.AddAsync(new Activity
        //     {
        //         Id = @event.Id,
        //         UserId = @event.UserId,
        //         Category = @event.Category,
        //         Name = @event.Name,
        //         CreatedAt = @event.CreatedAt,
        //         Description = @event.Description
        //     });
        //     Console.WriteLine($"Activity created: {@event.Name}");
        // }
         public async Task HandleAsync(UserCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"user created: {@event.Email}");
        }
    }
}