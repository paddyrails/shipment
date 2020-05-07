using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using Shipment.Common.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipment.Api.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBusClient _busClient;
        public UsersController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        [HttpGet("register")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await _busClient.PublishAsync(command);
            return Accepted();
        }
    }
}
