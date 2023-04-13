using Base.Modules.Users.Domain.DTO.CustomPower;
using Base.Shared.IServices;

namespace Base.Modules.Users.Domain.IServices
{
    public interface ICustomPowersService :
        ICRUDService1<GetCustomPowerResponseDto, GetCustomPowerDetailsResponseDto,CreateCustomPowerRequestDto,UpdateCustomPowerRequestDto>
    {
    }
}
