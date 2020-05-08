using System.Threading.Tasks;

namespace Shipment.Common.Mongo
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();       
    } 
}