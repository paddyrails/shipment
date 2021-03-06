﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shipment.Api.Handlers;
// using Shipment.Api.Repositories;
// using Shipment.Common.Auth;
using Shipment.Common.Events;
// using Shipment.Common.Mongo;
using Shipment.Common.RabbitMq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Shipment.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // services.AddJwt(Configuration);
            services.AddRabbitMq(Configuration);
            // services.AddMongoDB(Configuration);
            services.AddScoped<IEventHandler<ActivityCreated>, ActivityCreatedHandler>();
            // services.AddScoped<IActivityRepository, ActivityRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
