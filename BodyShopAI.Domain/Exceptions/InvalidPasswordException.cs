using System;

namespace Ats.Domain.Library.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public string PortugueseMessage { get; protected set; }

        public InvalidPasswordException()
        { }

        public InvalidPasswordException(string message)
            : base(message)
        { }

        public InvalidPasswordException(string message, string portugueseMessage)
            : base(message)
        {
            PortugueseMessage = portugueseMessage;
        }

        public InvalidPasswordException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}