using System;

namespace A5bark.Infrastructure.Exceptions.Definition
{
    public abstract class InfrastructureException : Exception
    {
        protected InfrastructureException(string message)
            : base(message) { }
    }
}
