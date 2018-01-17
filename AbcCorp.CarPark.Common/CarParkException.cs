using System;
using System.Runtime.Serialization;

namespace AbcCorp.CarPark.Common
{
    public class CarParkException : Exception
    {
        public CarParkException()
        {
        }

        public CarParkException(string message) : base(message)
        {
        }

        public CarParkException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CarParkException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
