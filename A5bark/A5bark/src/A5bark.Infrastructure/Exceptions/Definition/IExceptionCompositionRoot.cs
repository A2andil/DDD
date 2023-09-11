using A5bark.Application.Exceptions;
using System;

namespace A5bark.Infrastructure.Exceptions.Definition
{
    public interface IExceptionCompositionRoot
    {
        ExceptionResponse Map(Exception exception);
    }
}
