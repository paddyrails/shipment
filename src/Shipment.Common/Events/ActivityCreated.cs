using System;
using System.Collections.Generic;
using System.Text;

namespace Shipment.Common.Events
{
    public class ActivityCreated: IAuthenticatedEvent
    {
        public Guid Id { get;  }
        public Guid UserId { get;  }
        public string Category { get;  }
        public string Description { get;  }
        public string Name { get;  }
        public DateTime CreatedAt { get;  }

        public ActivityCreated(Guid id, Guid userId, string category, string description, string name, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            Category = category;
            Description = description;
            Name = name;
            CreatedAt = createdAt;
        }

    }
}
