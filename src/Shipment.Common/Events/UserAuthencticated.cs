using System;
using System.Collections.Generic;
using System.Text;

namespace Shipment.Common.Events
{
    public class UserAuthencticated : IEvent
    {
        public string Email { get; }

        protected UserAuthencticated() { }

        public UserAuthencticated(string email)
        {
            Email = email;
        }
    }
}
