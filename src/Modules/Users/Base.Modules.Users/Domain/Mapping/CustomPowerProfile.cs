using AutoMapper;
using Base.Modules.Users.Domain.DTO.CustomPower;
using Base.Modules.Users.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.Mapping
{
    public class CustomPowerProfile: Profile
    {
        public CustomPowerProfile()
        {
            CreateMap<CustomPower, GetCustomPowerDetailsResponseDto>();
            CreateMap<CustomPower, GetCustomPowerResponseDto>();
            CreateMap<CreateCustomPowerRequestDto, CustomPower>();
            CreateMap<UpdateCustomPowerRequestDto, CustomPower>();
        }
    }
}
