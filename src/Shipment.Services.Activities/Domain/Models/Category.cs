using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Shipment.Services.Activities.Domain.Models
{
    public class Category
    {
        public Guid Id {get; protected set;}
        public String Name {get; protected set;}

        protected Category(){}        

        public Category(string name){
            Id = Guid.NewGuid();
            Name = name;
        }

    }
}