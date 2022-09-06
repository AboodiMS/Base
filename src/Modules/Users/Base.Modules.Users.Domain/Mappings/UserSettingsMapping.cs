using Base.Modules.Users.Domain.DTO.UserSettings;
using Base.Modules.Users.Domain.Entities;
using Base.Shared.Helper101;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.Mappings
{
    public static class UserSettingsMapping
    {
       public static User AsEntity(this ChangePasswordRequestDto dto,User entity)
       {
            entity.HashCode = Guid.NewGuid().ToString();
            entity.HashPassword = dto.NewPassword.Trim().Encryption(entity.HashCode);
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdateUserId = dto.Id;

            return entity;
       }

    }
}
