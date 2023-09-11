using System;

namespace A5bark.Core.Exceptions
{
    public class InvalidTypedIdException : DomainException
    {
        public Guid Id { get; }
        public InvalidTypedIdException(Guid id)
            : base($"Invalid typed ID: '{id}'. Id value cannot be null or empty!")
                => Id = id;
    }
}
