using System;
using System.Threading.Tasks;
using Shipment.Services.Identity.Domain.Models;
using Shipment.Services.Identity.Repositories;
using Shipment.Common.Exceptions;
using Shipment.Services.Identity.Domain.Repositories;
using Shipment.Services.Identity.Domain.Services;

namespace Shipment.Services.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptor _encryptor;

        public UserService(IUserRepository userRepository, IEncryptor encryptor)
        {
            _userRepository = userRepository;
            _encryptor = encryptor;
        }
        public async Task RegisterAsync(string email, string password, string name)
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {                        
                throw new ShipmentException("email_in_use", $"Email already in use");            
            }
            
            user = new User(email, name);
            user.SetPassword(password, _encryptor);
            await _userRepository.AddAsync(user);
        }
        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {                        
                throw new ShipmentException("invalid_creds", $"Invalid creds");            
            }
            if(!user.ValidatePassword(password, _encryptor))
            {                        
                throw new ShipmentException("invalid_creds", $"Invalid creds");            
            }
        }
        
    }
}