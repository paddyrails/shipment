using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Common.Events
{
    interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}
