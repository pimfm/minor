using System;

namespace Frontend.Exceptions
{
    public class InvalidLineException : Exception
    {
        public readonly string FileName;

        public InvalidLineException(string message, string fileName) : this(message)
        {
            FileName = fileName;
        }

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