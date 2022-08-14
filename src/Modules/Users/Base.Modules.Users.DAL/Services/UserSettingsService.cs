using Base.Modules.Users.DAL.Database;
using Base.Modules.Users.Domain.DTO.User;
using Base.Modules.Users.Domain.DTO.UserSettings;
using Base.Modules.Users.Domain.Entities;
using Base.Modules.Users.Domain.IServices;
using Base.Modules.Users.Domain.Mappings;
using Base.Shared.Helper101;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Services
{
    public class UserSettingsService : IUserSettingsService
    {
        private readonly UsersDbContext _dbContext;
        private readonly ITreePowesService _treePowesService;

        public UserSettingsService(UsersDbContext dbContext,ITreePowesService treePowesService)
        {
            _dbContext = dbContext;
            _treePowesService = treePowesService;
        }
        private async Task<User> getById(Guid id, Guid businessId)
        {
            var entity = await _dbContext.Users.SingleAsync(a => a.Id == id 
                                                              && a.BusinessId == businessId 
                                                              && a.IsDeleted == false);
            if (entity == null)
                throw new Exception();
            return entity;
        }
        public async Task ChangeEmail(Guid id, Guid businessId, string email)
        {
            var entity = await getById(id, businessId);
            if(entity.Email==email)
                return;
            entity.Email = email;
            entity.VerifyEmailCode = "";
            entity.VerifyEmailDate = null;

            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdateUserId = id;
            await _dbContext.SaveChangesAsync();
        }
        public async Task ChangePassword(ChangePasswordRequestDto dto)
        {
            var entity = await getById(dto.Id, dto.BusinessId);
            dto.AsEntity(entity);
            await _dbContext.SaveChangesAsync();            
        }
        public async Task<GetUserDetailsResponseDto> GetUserInfo(Guid id, Guid businessId)
        {
            return (await getById(id, businessId)).AsDto(await _treePowesService.GetAsTreeAsync());
        }
        private async Task<List<string>> getAllRoles(List<string> powers,bool isadmin)
        {
            var roles = new List<string>();
            var _powers = await _dbContext.TreePowers.ToListAsync(); 
            if(isadmin)
            {
                foreach (var power in _powers)
                {
                    roles.Add(power.CodeName);
                    var dependsOn = _powers.Where(a => a.CodeName == power.CodeName).First().DependsOn?.ToList();
                    if (dependsOn != null)
                        foreach (string subrole in dependsOn)
                            roles.Add(subrole);
                }
                return roles;
            }
            foreach(string power in powers)
            {
                roles.Add(power);
                var dependsOn = _powers.Where(a => a.CodeName == power).First().DependsOn?.ToList();
                if(dependsOn != null)
                    foreach (string subrole in  dependsOn)
                        roles.Add(subrole);
            }
            return roles;
        }
        public async Task<string> LoginUsingUserName(LoginUsingUserNameRequestDto dto)
        {
            var entity = await _dbContext.Users.SingleAsync(a => a.BusinessId == dto.BusinessId 
                                                        && a.UserName == dto.UserName 
                                                        && a.IsDeleted == false );
            if (entity == null)
                throw new Exception();
           if(entity.HashPassword != dto.Password.Encryption(entity.HashCode))
                throw new Exception();
            var tocken = Shared.Security.Extensions.GenerateToken
                (entity.Id, entity.BusinessId,entity.UserName, await getAllRoles(entity.Powers.ToList(),entity.IsAdmin));

            return tocken.ToString();
        }
        public async Task<string> LoginUsingEmail(LoginUsingEmailRequestDto dto)
        {
            var entity = await _dbContext.Users.SingleAsync(a => a.BusinessId == dto.BusinessId
                                                                && a.Email == dto.Email
                                                                && a.IsDeleted == false);
            if (entity == null)
                throw new Exception();
            if (entity.HashPassword != dto.Password.Encryption(entity.HashCode))
                throw new Exception();

            var tocken = Shared.Security.Extensions.GenerateToken
                (entity.Id, entity.BusinessId, entity.UserName, await getAllRoles(entity.Powers.ToList(), entity.IsAdmin));

            return tocken.ToString();
        }
        public async Task VerifyEmail(Guid id, Guid businessId, string code)
        {
            var entity = await getById(id, businessId);
            if(entity.VerifyEmailDate.HasValue)
                throw new Exception();

            if (entity.HashCode == code)
                entity.VerifyEmailDate = DateTime.Now;
        }
        public Task SendVerifyCodeToEmail(Guid id, Guid businessId)
        {
           throw new NotImplementedException();
        }
        public Task SendURLToChangePasswordUsingEmail(Guid id, Guid businessId,string email)
        {
            throw new NotImplementedException();
        }
        public Task ChangePasswordUsingEmailURL(Guid id, Guid businessId, string email)
        {
            throw new NotImplementedException();
        }


        //07724480392

    }
}
