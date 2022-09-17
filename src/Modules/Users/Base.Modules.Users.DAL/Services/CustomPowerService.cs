using Base.Modules.Users.DAL.Database;
using Base.Modules.Users.Domain.DTO.CustomPower;
using Base.Modules.Users.Domain.Entities;
using Base.Modules.Users.Domain.IServices;
using Base.Modules.Users.Domain.Mappings;
using Base.Shared.Exceptions.ModulesExceptions;
using Base.Shared.Helper101;
using Base.Shared.Time;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Services
{
    public class CustomPowerService : ICustomPowersService
    {

        private readonly UsersDbContext _dbContext;

        public CustomPowerService(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        private async Task<CustomPower> getById(Guid id, Guid businessId)
        {
            var entity = await _dbContext.CustomPowers.SingleAsync(a => a.Id == id && a.BusinessId == businessId && a.IsDeleted == false);

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
            await IsNameExist(dto.Id, dto.Name, dto.BusinessId);

            var entity = dto.AsEntity();

            await _dbContext.CustomPowers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id, Guid businessId, Guid userid)
        {
            var entity = await getById(id, businessId);
            entity.Delete(userid);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<GetCustomPowerDetailsResponseDto> GetById(Guid id, Guid businessId)
        {
            var entity = await getById(id, businessId);
            return entity.AsDto();
        }

        public async Task Update(UpdateCustomPowerRequestDto dto)
        {
            await IsNameExist(dto.Id, dto.Name, dto.BusinessId);

            var entity = await getById(dto.Id, dto.BusinessId);

            dto.AsEntity(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<GetCustomPowerResponseDto>> GetAll(Guid businessId)
        {
            var entities = await _dbContext.CustomPowers.Where(x => x.BusinessId == businessId && x.IsDeleted == false).ToListAsync();
            return entities.AsDto();
        }
    }
}
