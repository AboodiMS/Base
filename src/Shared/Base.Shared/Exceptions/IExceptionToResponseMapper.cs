using System;

namespace Base.Shared.Exceptions
{
    internal interface IExceptionToResponseMapper
    {
        ExceptionResponse Map(Exception exception);
    }
}