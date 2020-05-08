using System;

namespace Shipment.Common.Exceptions
{
    //Marker Interface
    public class ShipmentException : Exception
    {
        public string Code { get; }

        public ShipmentException(){}

        public ShipmentException(string code)
        {
            Code = code;
        }

        public ShipmentException(string message, params object[] args) : this(string.Empty, message, args)
        {

        }

        public ShipmentException(string code, string message, params object[] args) : this(null, code, message, args)
        {

        }

        public ShipmentException(Exception innerException, string message, params object[] args) : this(innerException, string.Empty, message, args)
        {

        }

        public ShipmentException(Exception innerException,string code, string message, params object[] args) : base(string.Format(message, args), innerException)
        {
            Code = code;
        }


    }
}