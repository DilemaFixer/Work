using System;

namespace Code.Exceptions
{
    public class ValueRepeatsException : Exception
    {
        public ValueRepeatsException() : base() { }

        public ValueRepeatsException(string message) : base(message) { }

        public ValueRepeatsException(string message, Exception innerException) : base(message, innerException) { }
    }
}