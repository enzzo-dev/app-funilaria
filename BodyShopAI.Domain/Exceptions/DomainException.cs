using System;

namespace Ats.Domain.Library.Exceptions
{
    public class DomainException : Exception
    {
        public string PortugueseMessage { get; protected set; }

        public DomainException()
        { }

        public DomainException(string message)
            : base(message)
        { }

        public DomainException(string message, string portugueseMessage)
            : base(message)
        {
            PortugueseMessage = portugueseMessage;
        }

        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}