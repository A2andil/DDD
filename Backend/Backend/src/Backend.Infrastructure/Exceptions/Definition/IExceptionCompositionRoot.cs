using Backend.Application.Exceptions;
using System;

namespace Backend.Infrastructure.Exceptions.Definition
{
    public interface IExceptionCompositionRoot
    {
        ExceptionResponse Map(Exception exception);
    }
}
