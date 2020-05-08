using System;
using Shipment.Common.Exceptions;
using Shipment.Services.Identity.Domain.Services;

namespace Shipment.Services.Identity.Domain.Models
{
    public class User
    {
        public Guid Id {get; protected set;}
        public String Name {get; protected set;}
        public String Email {get; protected set;}
        public String Password {get; protected set;}
        public String Salt {get; protected set;}
        public DateTime CreatedAt {get; protected set;}

        protected User(){}        

        public User(string email, string name){

            
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new ShipmentException("empty_email_name", $"Email not valid");
            }

            
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ShipmentException("empty_user_name", $"User name cannot be emtpy");
            }

            Email = email.ToLowerInvariant();
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }


        public void SetPassword(string password, IEncryptor encryptor)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new ShipmentException("empty_password", $"Password empty");
            }
            Salt = encryptor.GetSalt(password);
            Password = encryptor.GetHash(password, Salt);
        }

        public bool ValidatePassword(string password, IEncryptor encryptor)
            => Password.Equals(encryptor.GetHash(password, Salt));

    }
}
