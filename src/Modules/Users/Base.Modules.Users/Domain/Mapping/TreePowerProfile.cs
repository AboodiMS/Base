using AutoMapper;
using Base.Modules.Users.Domain.DTO.TreePower;
using Base.Modules.Users.Domain.DTO.User;
using Base.Modules.Users.Domain.Entities;
using Base.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.Mapping
{
    public class TreePowerProfile: Profile
    {
         public TreePowerProfile()
         {
             CreateMap<TreePower, GetTreePowerResponseDto>();
             CreateMap<TreePower, GetUserResponseDto>();
             CreateMap<TreePower, User>();
         }
    }
}
