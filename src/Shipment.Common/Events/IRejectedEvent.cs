using System;
using System.Collections.Generic;
using System.Text;

namespace Shipment.Common.Events
{
    public interface IRejectedEvent : IEvent
    {
        public string Reason { get; }
        public string Code { get; }
    }
}
