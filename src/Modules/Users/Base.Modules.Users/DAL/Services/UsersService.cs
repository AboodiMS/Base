using Base.Modules.Users.DAL.Database;
using Base.Modules.Users.DAL.Exceptions.User;
using Base.Modules.Users.Domain.DTO.User;
using Base.Modules.Users.Domain.Entities;
using Base.Modules.Users.Domain.IServices;
using Base.Modules.Users.Domain.Mappings;
using Base.Shared.Database;
using Base.Shared.Exceptions.ModulesExceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Services
{
    public class UsersService :  IUsersService
    {
        private readonly UsersDbContext _dbContext;

        public UsersService(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        private async Task<User> getById(Guid id, Guid businessId)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(a => a.Id == id && a.BusinessId == businessId && a.IsDeleted == false);
            if (entity == null)
            {
                throw new NotFoundException(new ExceptionData
                {
                    TableName = "Users",
                    PropertieName = "Id",
                    PropertieValue= id.ToString(),
                }); 
            }
            return entity;
        }
        private async Task IsNameExist(Guid id, string name, Guid businessId)
        {
            var hasResulte= await _dbContext.Users
                .AnyAsync(a => a.Id != id && a.Name == name && a.BusinessId == businessId && a.IsDeleted == false);

            if(hasResulte)
                throw new ExistException(new ExceptionData
                {
                    TableName = "Users",
                    PropertieName = "Name",
                    PropertieValue = name,
                });
        }
        private async Task IsUserNameExist(Guid id, string username, Guid businessId)
        {
            var hasResulte = await _dbContext.Users
                .AnyAsync(a => a.Id != id && a.LoginName == username && a.BusinessId == businessId && a.IsDeleted == false);

            if (hasResulte)
                throw new ExistException(new ExceptionData
                {
                    TableName = "Users",
                    PropertieName = "UserName",
                    PropertieValue = username,
                });
        }
        private async Task IsEmailExist(Guid id, string email, Guid businessId)
        {
            var hasResulte = await _dbContext.Users
                .AnyAsync(a => a.Id != id && a.Email == email && a.BusinessId == businessId && a.IsDeleted == false);

            if (hasResulte)
                throw new ExistException(new ExceptionData
                {
                    TableName = "Users",
                    PropertieName = "Email",
                    PropertieValue = email,
                });
        }


        public async Task Create(CreateUserRequestDto dto)
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
            //Test();
            var entities = await _dbContext.Users.Where(x => x.BusinessId == businessId && x.IsDeleted == false).ToListAsync();
            return entities.AsDto();
        }
        public async Task<GetUserDetailsResponseDto> GetById(Guid id,Guid businessId)
        {
            var entity = await getById(id, businessId);
            return entity.AsDto();
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

        //private void Test()
        //{
        //    try
        //    {
        //        var context1 = new UsersDbContext(new DbContextOptionsBuilder<UsersDbContext>()
        //                  .UseNpgsql("Host=localhost;Database=Base;Username=postgres;Password=123@a")
        //                  .Options);
        //        var contactFromContext1 = context1.Users
        //                                          .FirstOrDefault(c => c.Name == "Test");
        //        if (contactFromContext1 == null)
        //        {
        //            contactFromContext1 = new User
        //            {
        //                Name = "Test"
        //            };
        //            context1.Add(contactFromContext1);
        //            context1.SaveChanges();
        //        }
        //        var context2 =
        //            new UsersDbContext(new DbContextOptionsBuilder<UsersDbContext>()
        //                                  .UseNpgsql("Host=localhost;Database=Base;Username=postgres;Password=123@a")
        //                                  .Options);
        //        var contactFromContext2 = context2.Users
        //                                          .FirstOrDefault(c => c.Name == "Test");
        //        contactFromContext1.Note = DateTimeOffset.Now.ToString();
        //        contactFromContext2.Note = DateTimeOffset.UtcNow.ToString();

        //        context1.SaveChanges();
        //        context2.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        throw;
        //    }
        //    //catch (Exception ex)
        //    //{

        //    //}


        //}

    }
}
