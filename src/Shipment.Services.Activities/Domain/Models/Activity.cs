using System;
using Shipment.Common.Exceptions;

namespace Shipment.Services.Activities.Domain.Models
{
    public class Activity
    {
        public Guid Id {get; protected set;}
        public String Name {get; protected set;}
        public String Category {get; protected set;}
        public String Description {get; protected set;}
        public Guid UserId {get; protected set;}
        public DateTime CreatedAt {get; protected set;}

        protected Activity(){}        

        public Activity(Guid id, Guid userId, string category, string name,  string description, DateTime createdAt){

            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ShipmentException("empty_activity_name", $"Activity name cannot be emtpy");
            }

            Id = id;
            Name = name;
            Category = category;
            Description = description;
            UserId = userId;
            CreatedAt = createdAt;
        }

    }
}