using Shipment.Common.Mongo;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Linq;
using Shipment.Services.Activities.Domain.Repositories;
using System.Collections.Generic;
using Shipment.Services.Activities.Domain.Models;

namespace Shipment.Services.Activities.Services
{
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly ICategoryRepository _categoryRepository;
        public CustomMongoSeeder(IMongoDatabase database, ICategoryRepository categoryRepository) : base(database)
        {
            _categoryRepository = categoryRepository;
        }

        protected override async Task CustomSeedAsync()
        {
            var categories = new List<string>
            {
                "work",
                "sport",
                "hobby"
            };
            await Task.WhenAll(categories.Select(x => 
                _categoryRepository.AddAsync(new Category(x))
            ));
        }
    }
}