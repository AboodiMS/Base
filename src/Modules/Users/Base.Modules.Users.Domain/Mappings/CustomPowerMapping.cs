using Base.Modules.Users.Domain.DTO.CustomPower;
using Base.Modules.Users.Domain.DTO.TreePower;
using Base.Modules.Users.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.Mappings
{
    public static class CustomPowerMapping
    {
        public static GetCustomPowerDetailsResponseDto AsDto(this CustomPower entity,TreePower TreePowers)
        {
            GetCustomPowerDetailsResponseDto dto = new GetCustomPowerDetailsResponseDto();

            dto.Id = entity.Id;
            dto.Name = entity.Name.Trim();
            dto.Note = entity.Note.Trim();
            dto.Powers = TreePowers.AsDto(entity.Powers.ToList());
            return dto;
        }
        public static GetCustomPowerResponseDto AsDto(this CustomPower entity)
        {
            GetCustomPowerResponseDto dto = new GetCustomPowerResponseDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name.Trim();
            return dto;
        }
    }
}
