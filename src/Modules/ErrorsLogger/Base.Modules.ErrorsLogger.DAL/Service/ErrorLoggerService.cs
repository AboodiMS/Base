using Base.Modules.ErrorsLogger.DAL.Database;
using Base.Modules.ErrorsLogger.Domain.DTO;
using Base.Modules.ErrorsLogger.Domain.IService;
using Base.Modules.ErrorsLogger.Domain.Mappings;
using Base.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.ErrorsLogger.DAL.Service
{
    public class ErrorLoggerService:IErrorLoggerService
    {
        private readonly ErrorsLoggerDbContext _dbContext;
        ErrorLoggerService(ErrorsLoggerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(CreateErrorLoggerDto dto)
        {
            await _dbContext.ErrorLogger.AddAsync(dto.AsEntity());
            await _dbContext.SaveChangesAsync();
        }
        public async Task CatchUnhandledException(CreateErrorLoggerDto dto)
        {
            switch (dto.Exception)
            {
                case DbUpdateConcurrencyException:
                    break;
                case BaseException:
                    break;
                default:
                    await Create(dto);
                    break;
            }
        }
    }
}
