
using Base.Modules.ErrorsLogger.Domain.DTO;
using Base.Modules.ErrorsLogger.Domain.Entities;
using Newtonsoft.Json;

namespace Base.Modules.ErrorsLogger.Domain.Mappings
{
    public static class ErrorLoggerMapping
    {
        public static ErrorLogger AsEntity(this CreateErrorLoggerDto dto)
        => new ErrorLogger
        {
            Id = Guid.NewGuid(),
            CreatedDate = DateTimeOffset.Now,
            Action = dto.Action,
            BusinessId = dto.BusinessId,
            Exception = JsonConvert.SerializeObject(new
            {
                HResult = dto.Exception.HResult,
                Message = dto.Exception.Message,
                HelpLink = dto.Exception.HelpLink,
                Name = dto.Exception.GetType().Name,
                InnerExceptionMessage = dto.Exception?.InnerException?.Message,
                InnerExceptionHResult = dto.Exception?.InnerException?.HResult,
                InnerExceptionHelpLink = dto.Exception?.InnerException?.HelpLink,
                InnerExceptionName = dto.Exception?.InnerException?.GetType().Name,
            }),
            InputData = JsonConvert.SerializeObject(dto.InputData),
            Class = dto.Class,
        };

    }
}
