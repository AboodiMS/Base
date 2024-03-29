﻿using Base.Modules.Users.Domain.DTO.TreePower;
using Base.Modules.Users.Domain.Entities;
using Base.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.Mappings
{
    public static class TreePowerMapping
    {
        private static List<string> _powers = new List<string>();

        public static GetTreePowerResponseDto AsDto(this TreePower entity, List<string> powers )
        {
            _powers = powers;
            return setData(entity);
        }

        public static GetTreePowerResponseDto AsDto(this TreePower entity)
        {
            return setData(entity);
        }

        private static GetTreePowerResponseDto setData(TreePower? entity)
        {      
            GetTreePowerResponseDto dto = new GetTreePowerResponseDto();
            dto.CodeName=entity.Code;
            dto.Name=entity.Name;
            dto.Num =entity.Num;
            dto.IsEndPoint=entity.IsEndPoint;
            dto.HasAccess = _powers.Where(a => a == dto.CodeName).Count() == 1;

            foreach (TreePower SubTreePower in entity.SubTreePowers.ToList())
            {
                dto.TreePowerNodes.Add(setData(SubTreePower));
            }
            return dto;
        }


    }
}
