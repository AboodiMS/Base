using Base.Modules.Users.Domain.DTO.CustomPower;
using Base.Modules.Users.Domain.DTO.TreePower;
using Base.Modules.Users.Domain.Entities;
using Base.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.Mappings
{
    public static class CustomPowerMapping
    {
        public static GetCustomPowerDetailsResponseDto AsDto(this CustomPower entity, List<TreePower> TreePowers)
        {
            GetCustomPowerDetailsResponseDto dto = new GetCustomPowerDetailsResponseDto();

            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Note = entity.Note;
            dto.Powers = TreePowers.Select(a=> a.AsDto(entity.Powers.ToList())).ToList();
            return dto;
        }
        public static GetCustomPowerResponseDto AsDto(this CustomPower entity)
        {
            GetCustomPowerResponseDto dto = new GetCustomPowerResponseDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            return dto;
        }

        public static CustomPower AsEntity(this AddCustomPowerRequestDto dto)
                => new CustomPower
                {
                        Id = dto.Id,
                        BusinessId = dto.BusinessId,
                        Name = dto.Name,
                        Note = dto.Note,
                        Powers = dto.Powers,

                        CreatedDate=DateTime.UtcNow,
                        CreatedUserId=dto.UserId,
                        IsDeleted=false,
                        LastUpdateDate=null,
                        LastUpdateUserId=null
                };

        public static CustomPower AsEntity(this UpdateCustomPowerRequestDto dto, CustomPower entity)
        {
            entity.Name = dto.Name;
            entity.Note = dto.Note;
            entity.Powers = dto.Powers;

            entity.LastUpdateDate = DateTime.UtcNow;
            entity.LastUpdateUserId = dto.UserId;
            return entity;
        }

    }
}
