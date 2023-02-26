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
    
        public async Task AddActionLogger(AddActionLoggerDto dto)
        {
            await _dbContext.ActionLogger.AddAsync(dto.AsEntity());
            await _dbContext.SaveChangesAsync();
        }

    }
}
