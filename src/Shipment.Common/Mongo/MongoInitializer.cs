using MongoDB.Driver;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson;

namespace Shipment.Common.Mongo
{
    public class MongoInitializer : IDatabaseInitializer
    {
        private bool _initialized;
        private readonly bool _seed;
        private readonly IDatabaseSeeder _seeder;

        private readonly IMongoDatabase _database;

        public MongoInitializer(IMongoDatabase database, IDatabaseSeeder seeder, IOptions<MongoOptions> options)
        {
            _seeder = seeder;
            _database = database;
            _seed = options.Value.Seed;
        }

        public async Task InitializeAsync()
        {
            if(_initialized){
                return;
            }
            RegisterConventions();
            _initialized = true;
            if(!_seed)
            {
                return;
            }
            await _seeder.SeedAsync();
        }

        private void RegisterConventions(){
            ConventionRegistry.Register("ActionConventions", new MongoConvention(), x => true);
        }

       private class MongoConvention : IConventionPack
        {
            public IEnumerable<IConvention> Conventions => new List<IConvention>
            {
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(BsonType.String),
                new CamelCaseElementNameConvention()
            };
        }

    }
}