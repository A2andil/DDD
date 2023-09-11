using System.Net;

namespace Backend.Application.Exceptions
{
    public record ExceptionResponse(object Response, HttpStatusCode StatusCode);
}
