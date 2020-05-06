using System;
using System.Collections.Generic;
using System.Text;

namespace Shipment.Common.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}
