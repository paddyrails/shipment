using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using Shipment.Common.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipment.Api.Controllers
{
    [Route("activities")]
    public class ActivitiesController : Controller
    {
        private readonly IBusClient _busClient;
        public ActivitiesController(IBusClient busClient)
        {
            _busClient = busClient;
        }
        
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateActivity command)
        {
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;
            
            await _busClient.PublishAsync(command);
            return Accepted($"activities/{command.Id}");
        }
    }
}
