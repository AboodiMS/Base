using Base.Modules.Users.Domain.DTO.TreePower;

namespace Base.Modules.Users.Domain.DTO.CustomPower
{
    public class GetCustomPowerDetailsResponseDto: GetCustomPowerResponseDto
    {
        public List<GetTreePowerResponseDto> Powers { get; set; } = new List<GetTreePowerResponseDto>();
    }
}
