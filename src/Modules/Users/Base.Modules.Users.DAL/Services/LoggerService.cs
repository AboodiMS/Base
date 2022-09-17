using Base.Modules.Users.DAL.Database;
using Base.Shared.DTO.Logger;
using Base.Shared.Entities;
using Base.Shared.Exceptions;
using Base.Shared.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Services
{
    public class LoggerService
    {
        private readonly UsersDbContext _dbContext;

        public LoggerService(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private async Task AddErrorLogger(AddErrorLoggerDto dto)
        {
            await _dbContext.ErrorLogger.AddAsync(dto.AsEntity());
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddActionLogger(AddActionLoggerDto dto)
        {
            await _dbContext.ActionLogger.AddAsync(dto.AsEntity());
            await _dbContext.SaveChangesAsync();
        }
        public async void CatchUnhandledException(AddErrorLoggerDto dto)
        {
            switch (dto.Exception)
            {
                case DbUpdateConcurrencyException:
                    break;
                case BaseException:
                    break;
                case Exception:
                    await AddErrorLogger(dto);
                    break;
            }
        }
    }
}
