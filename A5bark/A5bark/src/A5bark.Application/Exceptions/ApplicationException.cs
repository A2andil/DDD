using System;

namespace A5bark.Application.Exceptions
{
    public abstract class ApplicationException : Exception
    {
        protected ApplicationException(string message)
            : base(message) { }
    }
}
