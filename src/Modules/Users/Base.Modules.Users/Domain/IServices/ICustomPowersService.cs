using Base.Modules.Users.Domain.DTO.CustomPower;
using Base.Shared.IServices;

namespace Base.Modules.Users.Domain.IServices
{
    public interface ICustomPowersService :
        ICRUDService<GetCustomPowerResponseDto, GetCustomPowerDetailsResponseDto,CreateCustomPowerRequestDto,UpdateCustomPowerRequestDto>
    {
    }
}
