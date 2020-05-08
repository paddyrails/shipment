using System;
using System.Linq;
using System.Threading.Tasks;
using Shipment.Services.Activities.Domain.Models;
using Shipment.Services.Activities.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Shipment.Services.Activities.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase _database;
        
        public ActivityRepository(IMongoDatabase database){
            _database = database;
        }

        public async Task<Activity> GetAsync(Guid id)
            => await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(Activity Activity)
            => await Collection.InsertOneAsync(Activity);
        
        private IMongoCollection<Activity> Collection
            => _database.GetCollection<Activity>("Activities");
    }
}