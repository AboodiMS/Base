using Base.Modules.Users.DAL.Database;
using Base.Modules.Users.Domain.DTO.User;
using Base.Modules.Users.Domain.Entities;
using Base.Modules.Users.Domain.IServices;
using Base.Modules.Users.Domain.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Services
{
    public class UserService : 
        IUsersService<GetUserResponseDto,GetUserDetailsResponseDto, AddUserRequestDto, UpdateUserRequestDto>
    {
        private readonly UsersDbContext _dbContext;
        private readonly ITreePowesService _treePowesService;

        public UserService(UsersDbContext dbContext, ITreePowesService treePowesService)
        {
            _dbContext = dbContext;
            _treePowesService = treePowesService;
        }

        public async Task Add(AddUserRequestDto dto)
        {
            if (await IsNameExist(dto.Id, dto.Name, dto.BusinessId))
                throw new Exception();
            if (await IsUserNameExist(dto.Id, dto.UserName, dto.BusinessId))
                throw new Exception();
            if (await IsEmailExist(dto.Id, dto.Email, dto.BusinessId))
                throw new Exception();

           var entity = dto.AsEntity();
           await _dbContext.Users.AddAsync(entity);
           await _dbContext.SaveChangesAsync();
        }

        public async Task ChangePowers(ChangePowersRequestDto dto)
        {
            var entity = await getById(dto.Id ,dto.BusinessId);
            dto.AsEntity(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id,Guid businessId, Guid userid)
        {
            var entity = await getById(id, businessId);
            entity.Delete(userid);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<GetUserResponseDto>> GetAll(Guid businessId)
        {
           return await _dbContext.Users.Where(x => x.BusinessId == businessId && x.IsDeleted == false)
                                  .Select(a=>a.AsDto())
                                  .ToListAsync();
        }

        private async Task<User> getById(Guid id, Guid businessId)
        {
            var entity = await _dbContext.Users.SingleAsync(a => a.Id == id && a.BusinessId == businessId && a.IsDeleted == false);
            if (entity == null)
                throw new Exception();
            return entity;
        }

        private async Task<bool> IsNameExist(Guid id, string name, Guid businessId)
        {
            return await _dbContext.Users
                .AnyAsync(a => a.Id!=id && a.Name == name && a.BusinessId == businessId && a.IsDeleted == false );
        }

        private async Task<bool> IsUserNameExist(Guid id,string username, Guid businessId)
        {
            return await _dbContext.Users
                .AnyAsync(a => a.Id != id && a.UserName == username && a.BusinessId == businessId && a.IsDeleted == false);
        }

        private async Task<bool> IsEmailExist(Guid id, string email, Guid businessId)
        {
            return await _dbContext.Users
                .AnyAsync(a => a.Id != id && a.Email == email && a.BusinessId == businessId && a.IsDeleted == false);
        }

        public async Task<GetUserDetailsResponseDto> GetById(Guid id,Guid businessId)
        {
            var entity = await getById(id, businessId);
            return entity.AsDto(await _treePowesService.GetAsTreeAsync());
        }

        public async Task Update(UpdateUserRequestDto dto)
        {
            var entity = await getById(dto.Id, dto.BusinessId);

            if (await IsNameExist(dto.Id, dto.Name, dto.BusinessId))
                throw new Exception();
            if(await IsUserNameExist(dto.Id, dto.UserName, dto.BusinessId))
                throw new Exception();
            if (await IsEmailExist(dto.Id, dto.Email, dto.BusinessId))
                throw new Exception();

            dto.AsEntity(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
