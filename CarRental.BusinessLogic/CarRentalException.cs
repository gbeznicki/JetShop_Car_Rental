using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CarRental.BusinessLogic
{
    public class CarRentalException : Exception
    {
        public CarRentalException()
        {
        }

        public CarRentalException(string message) : base(message)
        {
        }

        public CarRentalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CarRentalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
