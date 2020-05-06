﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shipment.Common.Events
{
    public interface IAuthenticatedEvent : IEvent
    {
        Guid UserId { get; }
    }
}
