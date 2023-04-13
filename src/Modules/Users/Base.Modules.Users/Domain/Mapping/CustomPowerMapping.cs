using Base.Modules.Users.Domain.DTO.CustomPower;
using Base.Modules.Users.Domain.DTO.TreePower;
using Base.Modules.Users.Domain.Entities;
using Base.Shared.Database;
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
        public static GetCustomPowerDetailsResponseDto AsDto(this CustomPower entity)
        {
            GetCustomPowerDetailsResponseDto dto = new GetCustomPowerDetailsResponseDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Note = entity.Note;
            dto.Powers = BaseModulesData.TreePowers.Select(a => a.AsDto(entity.Powers.ToList())).ToList();
            return dto;
        }
        public static List<GetCustomPowerResponseDto> AsDto(this List<CustomPower> entities)
        {
            List<GetCustomPowerResponseDto> dtos = new List<GetCustomPowerResponseDto>();
            foreach(var entity in entities)
            {
                dtos.Add(new GetCustomPowerResponseDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Note=entity.Note,
                });
            }         
            return dtos;
        }

        public static CustomPower AsEntity(this CreateCustomPowerRequestDto dto)
                => new CustomPower
                {
                        Id = dto.Id,
                        BusinessId = dto.BusinessId,
                        Name = dto.Name,
                        Note = dto.Note,
                        Powers = dto.Powers,

                        CreatedDate=DateTimeOffset.UtcNow,
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

            entity.LastUpdateDate = DateTimeOffset.UtcNow;
            entity.LastUpdateUserId = dto.UserId;
            return entity;
        }

    }
}
