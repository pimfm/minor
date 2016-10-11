using System;

namespace Frontend.Exceptions
{
    public class InvalidLineException : Exception
    {
        public InvalidLineException()
        {
        }

        public InvalidLineException(string message) : base(message)
        {
        }

        public InvalidLineException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}