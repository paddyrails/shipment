using System;
using System.Threading.Tasks;

namespace Shipment.Services.Activities.Services
{
    public interface IActivityService
    {
        Task AddAsync(Guid id, Guid userId, string name, string category, string description, DateTime createdAt);
    }
}