using System.Net;

namespace Base.Shared.Exceptions
{
    public sealed record ExceptionResponse(object Response, HttpStatusCode StatusCode);
}