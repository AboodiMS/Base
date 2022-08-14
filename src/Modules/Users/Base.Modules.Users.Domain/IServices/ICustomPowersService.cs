using Base.Modules.Users.Domain.DTO.CustomPower;

namespace Base.Modules.Users.Domain.IServices
{
    public interface ICustomPowersService
    {
        Task<IEnumerable<GetCustomPowerResponseDto>> GetAll();
        Task<GetCustomPowerDetailsResponseDto> GetById(Guid Id);
    }
}
