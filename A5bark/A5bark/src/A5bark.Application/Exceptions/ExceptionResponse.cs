using System.Net;

namespace A5bark.Application.Exceptions
{
    public record ExceptionResponse(object Response, HttpStatusCode StatusCode);
}
