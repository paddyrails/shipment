using System.Reflection;
using System.Threading.Tasks;
using Shipment.Common.Commands;
using Shipment.Common.Events;
using Shipment.Common.Mongo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;
using MongoDB.Driver;

namespace Shipment.Common.Mongo
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();       
    } 
}