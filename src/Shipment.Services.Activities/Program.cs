﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shipment.Common.Commands;
using Shipment.Common.Services;

namespace Shipment.Services.Activities
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
               .UseRabbitMq()
               .SubscribeToCommand<CreateActivity>()
               .Build()
               .Run();
        }
    }
}
