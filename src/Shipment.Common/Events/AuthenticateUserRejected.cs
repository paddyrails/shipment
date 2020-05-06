using System;
using System.Collections.Generic;
using System.Text;

namespace Shipment.Common.Events
{
    public class AuthenticateUserRejected : IRejectedEvent
    {
        public string Email{ get; }
        public string Reason { get; }
        public string Code { get; }

        protected AuthenticateUserRejected() { }

        public AuthenticateUserRejected(string email, string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }

    }
}
