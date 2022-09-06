using Base.Modules.Users.DAL.Database;
using Base.Modules.Users.DAL.Exceptions.User;
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
    public class UsersService : 
        IUsersService<GetUserResponseDto,GetUserDetailsResponseDto, AddUserRequestDto, UpdateUserRequestDto>
    {
        private readonly UsersDbContext _dbContext;
        private readonly ITreePowesService _treePowesService;

        public UsersService(UsersDbContext dbContext, ITreePowesService treePowesService)
        {
            _dbContext = dbContext;
            _treePowesService = treePowesService;
        }


        private async Task<User> getById(Guid id, Guid businessId)
        {
            var entity = await _dbContext.Users.SingleAsync(a => a.Id == id && a.BusinessId == businessId && a.IsDeleted == false);
            if (entity == null)
                throw new UserNotFoundException(id);
            return entity;
        }
        private async Task IsNameExist(Guid id, string name, Guid businessId)
        {
            var resulte= await _dbContext.Users
                .AnyAsync(a => a.Id != id && a.Name == name && a.BusinessId == businessId && a.IsDeleted == false);

            throw new NameExistException(name);
        }
        private async Task IsUserNameExist(Guid id, string username, Guid businessId)
        {
            var resulte = await _dbContext.Users
                .AnyAsync(a => a.Id != id && a.LoginName == username && a.BusinessId == businessId && a.IsDeleted == false);
            throw new UserNameExistException(username);
        }
        private async Task IsEmailExist(Guid id, string email, Guid businessId)
        {
            var resulte = await _dbContext.Users
                .AnyAsync(a => a.Id != id && a.Email == email && a.BusinessId == businessId && a.IsDeleted == false);
            throw new EmailExistException(email);
        }


        public async Task Create(AddUserRequestDto dto)
        {
            await IsNameExist(dto.Id, dto.Name, dto.BusinessId);
            await IsUserNameExist(dto.Id, dto.UserName, dto.BusinessId);
            await IsEmailExist(dto.Id, dto.Email, dto.BusinessId);

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
        public async Task<GetUserDetailsResponseDto> GetById(Guid id,Guid businessId)
        {
            var entity = await getById(id, businessId);
            return entity.AsDto(await _treePowesService.GetAsTreeAsync());
        }
        public async Task Update(UpdateUserRequestDto dto)
        {
            await IsNameExist(dto.Id, dto.Name, dto.BusinessId);
            await IsUserNameExist(dto.Id, dto.UserName, dto.BusinessId);
            await IsEmailExist(dto.Id, dto.Email, dto.BusinessId);

            var entity = await getById(dto.Id, dto.BusinessId);

            dto.AsEntity(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
