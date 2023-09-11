using System;

namespace A5bark.Core.Exceptions
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message)
            : base(message) { }
    }
}
