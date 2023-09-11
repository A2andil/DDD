using A5bark.Infrastructure.Exceptions.Definition;

namespace A5bark.Infrastructure.Exceptions
{
    public class EmptyOrderException : InfrastructureException
    {
        public EmptyOrderException()
            : base($"Empty order defined.") { }
    }
}
