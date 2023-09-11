using Backend.Infrastructure.Exceptions.Definition;

namespace Backend.Infrastructure.Exceptions
{
    public class EmptyOrderException : InfrastructureException
    {
        public EmptyOrderException()
            : base($"Empty order defined.") { }
    }
}
