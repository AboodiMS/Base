
using Base.Modules.Users.DAL.Database;
using Base.Modules.Users.Domain.DTO.CustomPower;
using Base.Modules.Users.Domain.Entities;
using Base.Modules.Users.Domain.IServices;
using Base.Modules.Users.Domain.Mappings;
using Base.Shared.DTO.Logger;
using Base.Shared.Entities;
using Base.Shared.Exceptions;
using Base.Shared.Exceptions.ModulesExceptions;
using Base.Shared.Helper101;
using Base.Shared.Time;
using Microsoft.EntityFrameworkCore;

namespace Base.Modules.Users.DAL.Services
{
    public class CustomPowerService : ICustomPowersService
    {

        private readonly UsersDbContext _dbContext;
        private readonly LoggerService _loggerService;
        //private readonly IErrorLoggerService _errorLoggerService;

        public CustomPowerService(UsersDbContext dbContext
            //, IErrorLoggerService errorLoggerService
            )
        {
            _dbContext = dbContext;
            _loggerService = new LoggerService(dbContext);
            //_errorLoggerService = errorLoggerService;
        }

        private async Task<CustomPower> getById(Guid id, Guid businessId)
        {
            var entity = await _dbContext.CustomPowers.FirstOrDefaultAsync(a => a.Id == id && a.BusinessId == businessId && a.IsDeleted == false);
            if (entity is null)
                throw new NotFoundException(new ExceptionData
                {
                    TableName = "CustomPowers",
                    PropertieName = "Id",
                    PropertieValue = id.ToString()
                });
            return entity;
        }
        private async Task IsNameExist(Guid id, string name, Guid businessId)
        {
            var hasResulte = await _dbContext.Users
                .AnyAsync(a => a.Id != id && a.Name == name && a.BusinessId == businessId && a.IsDeleted == false);

            if(hasResulte)
                throw new ExistException(new ExceptionData
                {
                    TableName = "CustomPowers",
                    PropertieName = "Name",
                    PropertieValue = name
                });
        }



        public async Task Create(CreateCustomPowerRequestDto dto)
        {
            try
            {
                var entity = dto.AsEntity();
                await IsNameExist(dto.Id, dto.Name, dto.BusinessId);             
                await _dbContext.CustomPowers.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                await _loggerService.AddActionLogger(new AddActionLoggerDto
                {
                    ObjectData = entity,
                    Action = nameof(Create),
                    BusinessId = dto.BusinessId,
                    ObjectId = entity.Id,
                    Table = nameof(CustomPower),
                    UserId = dto.UserId
                });
            }
            catch(Exception ex)
            {
               //await _errorLoggerService.CatchUnhandledException(new CreateErrorLoggerDto
               // {
               //     Action = nameof(Create),
               //     BusinessId = dto.BusinessId,
               //     InputData = dto,
               //     Class= nameof(CustomPowerService),
               //     Exception=ex
               // });
                throw;
            }
        }

        public async Task Delete(Guid id, Guid businessId, Guid userid)
        {
            
            try
            {
                var entity = await getById(id, businessId);
                entity.Delete(userid);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                //await _errorLoggerService.CatchUnhandledException(new CreateErrorLoggerDto
                //{
                //    Action = nameof(Delete),
                //    BusinessId = businessId,
                //    InputData = new { Id = id, BusinessId = businessId },
                //    Class = nameof(CustomPowerService),
                //    Exception = ex
                //});
                throw;
            }
        }

        public async Task<GetCustomPowerDetailsResponseDto> GetById(Guid id, Guid businessId)
        {
            try
            {
                var entity = await getById(id, businessId);
                return entity.AsDto();
            }
            catch(Exception ex)
            {
                //await _errorLoggerService.CatchUnhandledException(new CreateErrorLoggerDto
                //{
                //    Action = nameof(GetById),
                //    BusinessId = businessId,
                //    InputData = new {Id = id, BusinessId=businessId},
                //    Class = nameof(CustomPowerService),
                //    Exception = ex
                //});
                throw;
            }
        }

        public async Task Update(UpdateCustomPowerRequestDto dto)
        {
            try
            {
                await IsNameExist(dto.Id, dto.Name, dto.BusinessId);
                var entity = await getById(dto.Id, dto.BusinessId);
                dto.AsEntity(entity);
                await _dbContext.SaveChangesAsync();
                await _loggerService.AddActionLogger(new AddActionLoggerDto
                {
                    ObjectData = entity,
                    Action = nameof(Update),
                    BusinessId = dto.BusinessId,
                    ObjectId = entity.Id,
                    Table = nameof(CustomPower),
                    UserId = dto.UserId
                });
            }
            catch(Exception ex)
            {
                //await _errorLoggerService.CatchUnhandledException(new CreateErrorLoggerDto
                //{
                //    Action = nameof(Update),
                //    BusinessId = dto.BusinessId,
                //    InputData = dto,
                //    Class = nameof(CustomPowerService),
                //    Exception = ex
                //});
                throw;
            }
        }

        public async Task<List<GetCustomPowerResponseDto>> GetAll(Guid businessId)
        {
            try
            {
                var entities = await _dbContext.CustomPowers.Where(x => x.BusinessId == businessId && x.IsDeleted == false).ToListAsync();
                return entities.AsDto();
            }
            catch(Exception ex)
            {
                //await _errorLoggerService.CatchUnhandledException(new CreateErrorLoggerDto
                //{
                //    Action = nameof(GetAll),
                //    BusinessId = businessId,
                //    InputData = new {BusinessId = businessId},
                //    Class = nameof(CustomPowerService),
                //    Exception = ex
                //});
                throw;
            }
        }
        
    }
}