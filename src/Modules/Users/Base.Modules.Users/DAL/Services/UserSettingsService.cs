﻿
using Base.Modules.Users.DAL.Database;
using Base.Modules.Users.DAL.Exceptions.User;
using Base.Modules.Users.DAL.Exceptions.UserSettings;
using Base.Modules.Users.Domain.DTO.User;
using Base.Modules.Users.Domain.DTO.UserSettings;
using Base.Modules.Users.Domain.Entities;
using Base.Modules.Users.Domain.IServices;
using Base.Modules.Users.Domain.Mappings;
using Base.Shared.DTO.Logger;
using Base.Shared.Exceptions.ModulesExceptions;
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
        private readonly LoggerService _loggerService;
        //private readonly IErrorLoggerService _errorLoggerService;

        public UserSettingsService(UsersDbContext dbContext
            //, IErrorLoggerService errorLoggerService
            )
        {
            _dbContext = dbContext;
            _loggerService = new LoggerService(dbContext);
            //_errorLoggerService = errorLoggerService;
        }


        private async Task<User> getById(Guid id, Guid businessId)
        {
            var entity = await _dbContext.Users.SingleOrDefaultAsync(a => a.Id == id 
                                                                       && a.BusinessId == businessId 
                                                                       && a.IsDeleted == false
                                                                       && a.IsActive);
            if (entity == null)
            {
                throw new NotFoundException(new ExceptionData
                {
                    TableName = "Users",
                    PropertieName = "Id",
                    PropertieValue = id.ToString(),
                });
            }
            return entity;
        }
        private async Task<User> getByEmail(string email, Guid businessId)
        {
            email= email.Trim();
            var entity = await _dbContext.Users.SingleAsync(a => a.Email == email
                                                              && a.BusinessId == businessId
                                                              && a.IsDeleted == false
                                                              && a.VerifyEmailDate.HasValue
                                                              && a.IsActive);
            if (entity == null)
                if (entity == null)
                {
                    throw new NotFoundException(new ExceptionData
                    {
                        TableName = "Users",
                        PropertieName = "Email",
                        PropertieValue = email,
                    });
                }
            return entity;
        }
        private async Task IsEmailExist(Guid id, string email, Guid businessId)
        {
            var resulte= await _dbContext.Users
                .AnyAsync(a => a.Id != id && a.Email == email && a.BusinessId == businessId && a.IsDeleted == false);

            if (resulte)
                throw new ExistException(new ExceptionData
                {
                    TableName = "Users",
                    PropertieName = "Email",
                    PropertieValue = email,
                });
        }
        private async Task<List<string>> getAllRoles(string[] powers, bool isadmin)
        {
            var roles = new List<string>();
            var _powers = await _dbContext.TreePowers.ToListAsync();
            if (isadmin)
            {
                roles.Add("admin");
                return roles;
            }
            
            foreach (string power in powers)
            {
                roles.Add(power);
                var dependsOn = _powers.Where(a => a.Code == power).First().DependsOn?.ToList();
                if (dependsOn != null)
                    foreach (string subrole in dependsOn)
                        roles.Add(subrole);
            }
            return roles;
        }


        public async Task ChangeEmail(Guid id, Guid businessId, string email)
        {

            try
            {
                var entity = await getById(id, businessId);
                email = email.Trim();
                if (entity.Email == email)
                    return;
                await IsEmailExist(id, email, businessId);
                entity.Email = email;
                entity.VerifyEmailCode = "";
                entity.VerifyEmailDate = null;

                entity.LastUpdateDate = DateTimeOffset.Now;
                entity.LastUpdateUserId = id;
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                //await _errorLoggerService.CatchUnhandledException(new CreateErrorLoggerDto
                //{
                //    Action = nameof(ChangeEmail),
                //    BusinessId = businessId,
                //    InputData = new { Id = id, BusinessId = businessId },
                //    Class = nameof(CustomPowerService),
                //    Exception = ex
                //});
                throw;
            }

        }
        public async Task ChangePassword(ChangePasswordRequestDto dto)
        {

            try
            {
                if (dto.NewPassword.Trim() != dto.ConfirmNewPassword.Trim())
                    throw new NewPasswordNotMatchException();
                var entity = await getById(dto.Id, dto.BusinessId);
                if (entity.HashPassword.Decryption(entity.HashCode) != dto.OldPassword)
                    throw new OldPasswordNotMatchException();
                dto.AsEntity(entity);
                await _dbContext.SaveChangesAsync();
            }       
            catch(Exception ex)
            {

            }
        }
        public async Task<GetUserDetailsResponseDto> GetUserInfo(Guid id, Guid businessId)
        {
            return (await getById(id, businessId)).AsDto();
        }
        public async Task<string> LoginUsingUserName(LoginUsingUserNameRequestDto dto)
        {
            try
            {
                var entity = await _dbContext.Users.SingleOrDefaultAsync(a => a.BusinessId == dto.BusinessId
                                                    && a.LoginName == dto.UserName
                                                    && a.IsDeleted == false
                                                    && a.IsActive);
                if (entity == null)
                    throw new ErrorUserNameOrPasswordException();
                if (entity.HashPassword != dto.Password.Encryption(entity.HashCode))
                    throw new ErrorUserNameOrPasswordException();
                var tocken = Shared.Security.Extensions.GenerateToken
                    (entity.Id, entity.BusinessId, entity.LoginName, await getAllRoles(entity.Powers, entity.IsAdmin));

                return tocken.ToString();
            }
            
            catch(Exception ex)
            {
                throw;
            }

        }
        public async Task<string> LoginUsingEmail(LoginUsingEmailRequestDto dto)
        {
            var entity = await _dbContext.Users.SingleAsync(a => a.BusinessId == dto.BusinessId
                                                                && a.Email == dto.Email
                                                                && a.IsDeleted == false
                                                                && a.IsActive);
            if (entity == null)
                throw new ErrorEmailOrPasswordExpcetion();
            if (entity.HashPassword != dto.Password.Encryption(entity.HashCode))
                throw new ErrorEmailOrPasswordExpcetion();

            var tocken = Shared.Security.Extensions.GenerateToken
                (entity.Id, entity.BusinessId, entity.LoginName, await getAllRoles(entity.Powers, entity.IsAdmin));

            return tocken.ToString();
        }
        public async Task VerifyEmail(Guid id, Guid businessId, string code)
        {
            var entity = await getById(id, businessId);
            if(entity.VerifyEmailDate.HasValue)
                throw new EmailAlreadyVerifiedException();

            if (entity.VerifyEmailCode == code.Trim())
            {
                entity.VerifyEmailCode = string.Empty;
                entity.VerifyEmailDate = DateTimeOffset.Now;
            }
        }
        public async Task SendVerifyCodeToEmail(Guid id, Guid businessId)
        {
            var entity = await getById(id,businessId); 
            if (string.IsNullOrWhiteSpace(entity.Email))
                throw new NoEmailException();
            if(entity.VerifyEmailDate.HasValue)
                throw new EmailAlreadyVerifiedException();
            var transaction = _dbContext.Database.BeginTransaction();
            Random rd = new Random();
            int rand_num = rd.Next(100000, 999999);
            entity.VerifyEmailCode= rand_num.ToString();
            await _dbContext.SaveChangesAsync();
            await MailService.SendMail(entity.Email, "Verify Code", entity.VerifyEmailCode);
            await transaction.CommitAsync();
        }
        public async Task ChangePasswordAndSendUsingEmail(Guid businessId,string email)
        {
            var entity = await getByEmail(email.Trim(), businessId);
            var transaction = _dbContext.Database.BeginTransaction();

            Random rd = new Random();
            int rand_num = rd.Next(100000, 999999);
            string password = rand_num.ToString();
            entity.HashCode = Guid.NewGuid().ToString();
            entity.HashPassword = password.Encryption(entity.HashCode);

            await _dbContext.SaveChangesAsync();
            await MailService.SendMail(entity.Email, "New Password", password);
            await transaction.CommitAsync();
        }
    }
}
