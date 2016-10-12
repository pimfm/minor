using System;
using System.Text.RegularExpressions;

namespace Exceptions
{
    public class PatternDidNotMatchException : Exception
    {
        public string Line { get; private set; }
        public Regex Pattern { get; private set; }

        public PatternDidNotMatchException(Regex pattern, string line)
        {
            Pattern = pattern;
            Line = line;
        }

        public PatternDidNotMatchException()
        {
        }

        public PatternDidNotMatchException(string message) : base(message)
        {
        }

        public PatternDidNotMatchException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}