﻿using Base.Modules.Users.DAL.Database;
using Base.Modules.Users.Domain.DTO.TreePower;
using Base.Modules.Users.Domain.Entities;
using Base.Modules.Users.Domain.IServices;
using Base.Modules.Users.Domain.Mappings;
using Base.Shared.Database;
using Base.Shared.Entities;
using Base.Shared.Helper101;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Base.Modules.Users.DAL.Services
{
    public class TreePowesService : ITreePowesService
    {



        public List<GetTreePowerResponseDto> GetAll()
        {
            return BaseModulesData.TreePowers.Select(a=>a.AsDto()).ToList();
        }
    }
}
