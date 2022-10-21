using Base.Modules.ErrorsLogger.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.ErrorsLogger.Domain.IService
{
    public interface IErrorLoggerService
    {
        Task Create(CreateErrorLoggerDto dto);
        Task CatchUnhandledException(CreateErrorLoggerDto dto);
    }
}
