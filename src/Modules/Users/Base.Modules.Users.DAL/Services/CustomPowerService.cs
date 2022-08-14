using Base.Modules.Users.DAL.Database;
using Base.Modules.Users.DAL.Exceptions.CustomPower;
using Base.Modules.Users.Domain.DTO.CustomPower;
using Base.Modules.Users.Domain.Entities;
using Base.Modules.Users.Domain.IServices;
using Base.Modules.Users.Domain.Mappings;
using Base.Shared.Helper101;
using Base.Shared.Time;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Services
{
    public class CustomPowerService : ICustomPowersService
    {

        private readonly UsersDbContext _dbContext;
        private readonly ITreePowesService _treePowesService;

        public CustomPowerService(UsersDbContext dbContext, ITreePowesService treePowesService)
        {
            _dbContext = dbContext;
            _treePowesService = treePowesService;
        }

        public async Task<IEnumerable<GetCustomPowerResponseDto>> GetAll()
        {
            var entities = await _dbContext.CustomPowers.ToListAsync();
            return entities.Select(e => e.AsDto());
        }

        public async Task<GetCustomPowerDetailsResponseDto> GetById(Guid Id)
        {
            var entity = await _dbContext.CustomPowers.FindAsync(Id);
            if(entity is null)
                throw new CustomPowerNotFoundException(Id);

            return entity.AsDto(await _treePowesService.GetAsTreeAsync());
        }

    }
}
