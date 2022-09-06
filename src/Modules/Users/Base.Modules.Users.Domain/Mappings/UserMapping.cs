using Base.Modules.Users.Domain.DTO.TreePower;
using Base.Modules.Users.Domain.DTO.User;
using Base.Modules.Users.Domain.Entities;
using Base.Shared.Entities;
using Base.Shared.Helper101;

namespace Base.Modules.Users.Domain.Mappings
{
    public static class UserMapping
    {
        public static User AsEntity(this AddUserRequestDto dto)
        {
            var entity=new User();        



            entity.LoginName = dto.UserName.Trim();
            entity.Name = dto.Name.Trim();
            entity.IsAdmin = dto.IsAdmin;
            entity.HashCode =Guid.NewGuid().ToString();
            entity.HashPassword = dto.Password.Encryption(entity.HashCode);
            entity.Email = string.IsNullOrWhiteSpace(dto.Email) ? null: dto.Email.Trim();
            entity.VerifyEmailCode=string.Empty;
            entity.VerifyEmailDate = null;
            entity.PhonNum = dto.PhonNum.Trim();
            entity.Note = dto.Note.Trim();
            entity.Powers = dto.Powers;
            entity.IsActive = dto.IsActive;
            entity.SignOutExpirationDate = null;


            entity.Id = dto.Id;
            entity.BusinessId = dto.BusinessId;        
            entity.IsDeleted = false;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedUserId = dto.UserId;
            entity.LastUpdateDate = null;
            entity.LastUpdateUserId = null;

            return entity;  
        }
        public static User AsEntity(this UpdateUserRequestDto dto,User entity)
        {
            entity.LoginName = dto.UserName.Trim();
            entity.Name = dto.Name.Trim();
           
            if (entity.Email != dto.Email.Trim() || string.IsNullOrWhiteSpace(dto.Email))
            {
                entity.Email = string.IsNullOrWhiteSpace(dto.Email) ? null : dto.Email.Trim();
                entity.VerifyEmailCode = string.Empty;
                entity.VerifyEmailDate = null;
            }          
            entity.PhonNum = dto.PhonNum.Trim();
            entity.Note = dto.Note.Trim();
            entity.IsActive = dto.IsActive;


            entity.LastUpdateUserId = dto.UserId;
            entity.LastUpdateDate = DateTime.Now;

            return entity;
        }
        public static User AsEntity(this ChangePowersRequestDto dto, User entity)
        {
            entity.IsAdmin = dto.IsAdmin;
            entity.Powers=dto.Powers;

            entity.LastUpdateUserId = dto.UserId;
            entity.LastUpdateDate = DateTime.Now;

            return entity;
        }
        public static GetUserDetailsResponseDto AsDto(this User entity, List<TreePower> TreePowers)
        {
            GetUserDetailsResponseDto dto=new GetUserDetailsResponseDto();
            dto.Id = entity.Id;
            dto.UserName = entity.LoginName.Trim();
            dto.Name = entity.Name.Trim();
            dto.Note = entity.Note.Trim();
            dto.Email = entity.Email?.Trim();
            dto.IsAdmin =entity.IsAdmin;
            dto.PhonNum = entity.PhonNum.Trim();
            dto.IsEmailVerified = entity.VerifyEmailDate.HasValue;
            dto.IsActive= entity.IsActive;

            dto.Powers = new List<GetTreePowerResponseDto>();
            if (entity.Powers != null)
                dto.Powers = TreePowers.Select(a=>a.AsDto(entity.Powers.ToList())).ToList();

            return dto;
        }
        public static GetUserResponseDto AsDto(this User entity)
        {
            GetUserResponseDto dto = new GetUserResponseDto();
            dto.Id = entity.Id;
            dto.UserName = entity.LoginName;
            dto.Name = entity.Name;
            dto.Email = entity.Email;
            dto.IsAdmin = entity.IsAdmin;
            dto.PhonNum = entity.PhonNum;
            dto.IsEmailVerified = entity.VerifyEmailDate.HasValue;
            dto.IsActive = entity.IsActive;

            return dto;
        }
    }
}
