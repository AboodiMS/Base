using Base.Modules.Users.Domain.DTO.CustomPower;
using Base.Modules.Users.Domain.Entities;
using Base.Shared.Helper101;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.IServices
{
    public interface ICustomPowersService
    {
        Task<GetCustomPowerResponseDto> GetAll();
        Task<GetCustomPowerDetailsResponseDto> GetById(Guid Id);
    }
}
