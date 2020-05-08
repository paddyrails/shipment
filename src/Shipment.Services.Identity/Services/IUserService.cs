using System;
using System.Threading.Tasks;
using Shipment.Services.Identity.Domain.Models;

namespace Shipment.Services.Identity.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string password, string name);
        Task LoginAsync(string email, string password);
        
    }
}